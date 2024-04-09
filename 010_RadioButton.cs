using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _010_RadioButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";

            if (rbkorea.Checked)
                result += "국적 : 대한민국\n";
            else if (rbChina.Checked)
                result += "국적 : 중국\n";
            else if (rbJapan.Checked)
                result += "국적 : 일본\n";
            else if (rbOthers.Checked)
                result += "국적 : 그 외 국가\n";
            

            if (rbMale.Checked) // if (checkedRB == rbMale)
                result += "성별 : 남성";
            else if (rbFemale.Checked) // if (checkedRB == rbFemale)
                result += "성별 : 여성";

            MessageBox.Show(result, "국적/성별");
        }
    }
}
