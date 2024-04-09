using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _004_bmiForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = double.Parse(txtH.Text);
            double w = double.Parse(txtW.Text);
            double bmi = w / ((h / 100) * (h / 100));

            lblBMI.Text = "BMI = " + bmi.ToString("#.##");

            if (bmi < 20)
            {
                lblResult.Text = "판정 : " + "저체중";
                pictureBox1.BackColor = Color.Blue;
            }
            else if (bmi < 25)
            {
                lblResult.Text = "판정 : " + "정상체중";
                pictureBox1.BackColor = Color.Green;
            }
            else if (bmi < 30)
            {
                lblResult.Text = "판정 : " + "경도비만";
                pictureBox1.BackColor = Color.Yellow;
            }
            else if (bmi < 35)
            {
                lblResult.Text = "판정 : " + "비만";
                pictureBox1.BackColor = Color.Orange;
            }
            else
            {
                lblResult.Text = "판정 : " + "고도비만";
                pictureBox1.BackColor = Color.Red;
            }
        }
    }
}
