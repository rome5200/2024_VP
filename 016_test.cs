using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _016_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 1; i <= 4; i++)
            {
                cb_grade.Items.Add(i);
            }
            cb_grade.SelectedItem = 2;

            cb_life.Items.Add("기숙사");
            cb_life.Items.Add("자취");
            cb_life.Items.Add("통학");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            RadioButton[] major = new RadioButton[] { rb1, rb2, rb3, rb4, rb5};
            String result = "";
            if(rb1.Checked)
                result = rb1.Text\n;
            else if(rb2.Checked)
                result = rb2.Text\n;
            else if(rb3.Checked)
                result = rb3.Text\n;
            else if(rb4.Checked)
                result = rb4.Text\n;
            else if(rb5.Checked)
                result = rb5.Text\n;
            
            string result += cb_grade.Text + "학년\n"+
                txt_num.Text + "\n" + txt_name.Text.ToString() + "\n" + cb_life.Text.ToString();

           MessageBox.Show(result, "학생정보");
        
        }
    }
}
