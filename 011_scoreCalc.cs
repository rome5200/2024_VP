using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _011_scoreCalc // 교재 421p
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Button Click 이벤트 처리 함수
        private void button1_Click(object sender, EventArgs e)
        {    
            // 국어, 수학, 영어 텍스트박스의 값을 Double로 변환하고
            // 합을 구하여 sum에 저장
            double sum = Convert.ToDouble(txtKor.Text) +
                Convert.ToDouble(txtMath.Text) +
                Convert.ToDouble(txtEng.Text);
            
            // 평균을 저장하는 변수 avg
            double avg = sum / 3;

            // sum과 avg를 문자열로 변환한 후 표시
            // avg는 소수점 한자리까지만 표시
            txtSum.Text = sum.ToString();
            txtAvg.Text = avg.ToString("0.0");
        }
    }
}
