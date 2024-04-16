using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Data;
using System.Windows.Forms;

namespace _022_firebase
{
  public partial class Form1 : Form
  {
    DataTable dt = new DataTable();

    IFirebaseConfig config = new FirebaseConfig
    {
      AuthSecret = "btWERSK1LXtr37Qs27MSRzTBLmxAWJOggMhsjLZT",
      BasePath = "https://aaaaa-87c75-default-rtdb.firebaseio.com/"
    };
    IFirebaseClient client;

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      client = new FireSharp.FirebaseClient(config);

      if(client != null )
      {
        MessageBox.Show("Connection 성공!");
      }

      dt.Columns.Add("Id");
      dt.Columns.Add("학번");
      dt.Columns.Add("이름");
      dt.Columns.Add("전화번호");

      dataGridView1.DataSource = dt;
      
      export();
    }

    private async void btnInsert_Click(object sender, EventArgs e)
    {
      // Firebase에서 cnt 가져오기
      FirebaseResponse r = await client.GetAsync("Counter/");
      Counter c = r.ResultAs<Counter>();

      if (txtId.Text != "")
        MessageBox.Show("Id는 auto increase이므로 무시됩니다!");

      var data = new Data
      {
        //Id = txtId.Text,
        Id = (c.cnt+1).ToString(),
        SId = txtSId.Text,
        Name = txtName.Text,
        Phone = txtPhone.Text
      };

      SetResponse response =
        await client.SetAsync("Phonebook/" + data.Id, data);
      //await client.SetAsync("Phonebook/" + txtId.Text, data);
      Data result = response.ResultAs<Data>();

      MessageBox.Show("Data Inserted! Id = " + result.Id);

      // Counter를 업데이트
      var obj = new Counter
      {
        cnt = c.cnt + 1
      };
      SetResponse resp 
        = await client.SetAsync("Counter/", obj);

      dt.Rows.Clear();
      export();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
      Clear();  
    }

    private void Clear()
    {
      txtId.Text = "";
      txtSId.Text = "";
      txtName.Text = "";
      txtPhone.Text = "";
    }

    private async void btnRetrieve_Click(object sender, EventArgs e)
    {
      if (txtId.Text == "")
        return;

      FirebaseResponse r 
        = await client.GetAsync("Phonebook/" + txtId.Text);

      Data d = r.ResultAs<Data>();
      
      if (d == null)
      {
        MessageBox.Show("Id가 " + txtId.Text + "인 데이터가 없습니다!");
        return;
      }

      txtId.Text = d.Id;
      txtSId.Text = d.SId;
      txtName.Text = d.Name;
      txtPhone.Text = d.Phone;

      MessageBox.Show("Data Retrieved successfully!");

    }

    private async void btnUpdate_Click(object sender, EventArgs e)
    {
      var data = new Data
      {
        Id = txtId.Text,
        Name = txtName.Text,
        Phone = txtPhone.Text,
        SId = txtSId.Text        
      };
      FirebaseResponse r = await 
        client.UpdateAsync("Phonebook/"+txtId.Text, data);

      Data d = r.ResultAs<Data>();

      dt.Rows.Clear();

      export();

      MessageBox.Show("Data Updated Succefully! Id = " + d.Id);
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
      FirebaseResponse r = await
        client.DeleteAsync("Phonebook/" + txtId.Text);
      
      dt.Rows.Clear();
      export();
      MessageBox.Show("Deleted! : id = " + txtId.Text);

    }

    private async void btnDeleteAll_Click(object sender, EventArgs e)
    {
      DialogResult answer = MessageBox.Show(
        "저장된 모든 데이터가 삭제됩니다. 계속하시겠습니까?",
        "Warning!", MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

      if (answer == DialogResult.No) 
        return;

      FirebaseResponse r = await
        client.DeleteAsync("Phonebook");

      var obj = new Counter
      {
        cnt = 0
      };

      SetResponse resp = await client.SetAsync("Counter/", obj);

      dt.Rows.Clear();
      export();
      Clear();
      MessageBox.Show("All data at Phonebook/ Deleted!");
    }

    private void btnViewAll_Click(object sender, EventArgs e)
    {
      dt.Rows.Clear();
      export();
    }

    private async void export()
    {
      int i = 0;
      FirebaseResponse r = await client.GetAsync("Counter/");
      Counter obj = r.ResultAs<Counter>();
      int cnt = obj.cnt;

      while(i != cnt)
      {
        i++;
        FirebaseResponse resp 
          = await client.GetAsync("Phonebook/" + i);
        Data d = resp.ResultAs<Data>();

        if (d != null)
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

    private void dataGridView1_CellClick(object sender, 
      DataGridViewCellEventArgs e)
    {
      DataGridView dgv = (DataGridView)sender;
      
      if(e.RowIndex < 0) 
      {
        return;
      }
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
