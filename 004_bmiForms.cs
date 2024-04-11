using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _004_bmiForms // 교재 136p 참고
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          //Click 이벤트 처리함수.
        private void button1_Click(object sender, EventArgs e)
        {
            double h = double.Parse(txtH.Text); // 키를 나타내는 변수 h 선언
            double w = double.Parse(txtW.Text); // 체중을 나타내는 변수 w 선언
            double bmi = w / ((h / 100) * (h / 100)); // bmi를 나타내는 변수 bmi 선언
            // bmi 계산법 = 체중 / (키(m))^2

            lblBMI.Text = "BMI = " + bmi.ToString("#.##"); // lblBMI에 bmi를 소수점 둘째자리까지출력

            // bmi 값이 20미만일 경우 lblResult에 "판정 : 저체중"을 출력하고
            // pictureBox에 파란색을 출력
            if (bmi < 20) 
            {
                lblResult.Text = "판정 : " + "저체중";
                pictureBox1.BackColor = Color.Blue;
            }
            // bmi 값이 20이상 25미만일 경우 lblResult에 "판정 : 정상체중"을 출력하고
            // pictureBox에 초란색을 출력
            else if (bmi < 25)
            {
                lblResult.Text = "판정 : " + "정상체중";
                pictureBox1.BackColor = Color.Green;
            }
            // bmi 값이 25이상 30미만일 경우 lblResult에 "판정 : 경도비만"을 출력하고
            // pictureBox에 노란색을 출력
            else if (bmi < 30)
            {
                lblResult.Text = "판정 : " + "경도비만";
                pictureBox1.BackColor = Color.Yellow;
            }
            // bmi 값이 30이상 35미만일 경우 lblResult에 "판정 : 비만"을 출력하고
            // pictureBox에 주황색을 출력
            else if (bmi < 35)
            {
                lblResult.Text = "판정 : " + "비만";
                pictureBox1.BackColor = Color.Orange;
            }
            // bmi 값이 40이상일 경우 lblResult에 "판정 : 고도비만"을 출력하고
            // pictureBox에 빨간색을 출력
            else
            {
                lblResult.Text = "판정 : " + "고도비만";
                pictureBox1.BackColor = Color.Red;
            }
        }
    }
}
