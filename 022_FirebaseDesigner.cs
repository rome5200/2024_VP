using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace _022_FirebaseDesinger
{
    public partial class Form1 : Form
    {
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
        }
        // Firebase DB에 데이터 추가
        // CS와 Firebase는 async로 연결한다.
        private async void btnInsert_Click(object sender, EventArgs e)
        {
            var data = new Data
            // 프로젝트에 클래스로 추가한다.
            {
                Id = txtId.Text,
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            SetResponse response = await
                client.SetAsync("Phonebook/" + txtId.Text, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted : Id =", result.Id);
        }

        // 텍스트박츠 창에 입력된 내용 삭제
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtSId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        // 검색 버튼
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
                client.GetAsync("Phonebook/" + txtId.Text);
            Data obj = response.ResultAs<Data>();

            txtId.Text= obj.Id;
            txtSId.Text = obj.SId;
            txtName.Text = obj.Name;
            txtPhone.Text = obj.Phone;

            MessageBox.Show("Data reterived successful!");
        }

        // 데이터 수정
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Id = txtId.Text,
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            FirebaseResponse response = await
                client.UpdateAsync("Phonebook/"+txtId.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data updated successfully! : id = " + result.Id);
        }

        // 삭제
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
                client.DeleteAsync("Phonebook/" + txtId.Text);
            MessageBox.Show("Deleted! : id = ", txtId.Text);
        }

        // 모두 삭제
        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
                client.DeleteAsync("Phonebook");
            MessageBox.Show("All Data at /Phonebook node deleted!");
        }
    }
}
