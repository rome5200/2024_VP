using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Data;
using System.Windows.Forms;

namespace _022_FirebaseDesinger
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        
        // Firebase DB와 연결
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "L8Xw5cW99BPo7U4jEkQMdByN5duatmW5HYw3NQ0O",
            BasePath = "https://vp2024-e6d00-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public Form1()
        {
            InitializeComponent();
        }

        //Firebase와 연결되었다면 메시지박스 출력
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Connetion 성공!");
            }

            dt.Columns.Add("Id");
            dt.Columns.Add("학번");
            dt.Columns.Add("이름");
            dt.Columns.Add("전화번호");

            dataGridView1.DataSource = dt;

            export(); // 데이터를 읽어와서 데이터 그리드 뷰에 출력
        }
        // Firebase DB에 데이터 추가
        // CS와 Firebase는 async로 연결한다.
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            FirebaseResponse r = await client.GetAsync("Counter/");
            Counter c = r.ResultAs<Counter>();

            if (txtId.Text != "")
                MessageBox.Show("ID는 Auto increse이므로\n 입력된 ID는 무시됩니다.");

            var data = new Data
            // 프로젝트에 클래스로 추가한다.
            {
                Id = (c.cnt+1).ToString(),
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            SetResponse response = 
                await client.SetAsync("Phonebook/" + data.Id, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data inserted : Id =" + result.Id, "Insert");

            var obj = new Counter
            {
                cnt = c.cnt + 1
            };
            SetResponse response1 = await client.SetAsync("Counter/", obj);

            dt.Rows.Clear();
            export();
        }

        // 텍스트박츠 창에 입력된 내용 삭제
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        // 데이터 검색
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
                return;

            FirebaseResponse r 
                = await client.GetAsync("Phonebook/" + txtId.Text);

            Data d = r.ResultAs<Data>();

            if(d == null)
            {
                MessageBox.Show("Id가 " + txtId.Text + "인 데이터가 없습니다!");
                return;
            }

            txtId.Text= d.Id;
            txtSId.Text = d.SId;
            txtName.Text = d.Name;
            txtPhone.Text = d.Phone;

            MessageBox.Show("Data reterived successful!", "Search");
        }

        // 데이터 수정
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            // Firebase에서 cnt 가져오기
            FirebaseResponse r = await client.GetAsync("Counter/");
            Counter c = r.ResultAs<Counter>();
            var data = new Data
            {
                //Id = txtId.Text,
                Id = (c.cnt+1).ToString(),
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            FirebaseResponse response = await
                client.UpdateAsync("Phonebook/" + txtId.Text, data);
            Data result = response.ResultAs<Data>();

            dt.Rows.Clear();
            export();

            MessageBox.Show("Data updated successfully! : id = " + result.Id);
        }

        // 삭제
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
                client.DeleteAsync("Phonebook/" + txtId.Text);

            dt.Rows.Clear();
            export();

            MessageBox.Show("Deleted! : id = " + txtId.Text);

        }

        // 모든 데이터 삭제
        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "저장된 모든 데이터가 삭제됩니다. 계속 하시겠습니까?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer == DialogResult.No)
                return;

            FirebaseResponse response = await
                client.DeleteAsync("Phonebook");
            var obj = new Counter
            {
                cnt = 0
            };

            SetResponse resp = await client.SetAsync("Counter/", obj);

            dt.Rows.Clear();
            export();
            Clear();

            MessageBox.Show("All Data at /Phonebook deleted!");
        }

        private void Clear()
        {
            txtId.Text = "";
            txtSId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            // Counter 읽어오기 테스트
            //FirebaseResponse r = await client.GetAsync("Counter/");
            //Counter c = r.ResultAs<Counter>();
            //MessageBox.Show("cnt = " + c.cnt);

            dt.Rows.Clear();
            export();
        }

        private async void export()
        {
            int i = 0;
            FirebaseResponse r = await client.GetAsync("Counter/");
            Counter obj = r.ResultAs<Counter>();
            int cnt = obj.cnt;

            while ( i != cnt)
            {
                i++;
                FirebaseResponse resp = await client.GetAsync("Phonebook/" + i);
                Data d = resp.ResultAs<Data>();

                if (d != null )
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = d.Id;
                    row["학번"] = d.SId;
                    row["이름"] = d.Name;
                    row["전화번호"] = d.Phone;
                    dt.Rows.Add(row);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;
            txtId.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSId.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}