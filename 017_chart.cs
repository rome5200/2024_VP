using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _018_chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Form Load 이벤트 처리 함수
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Titles.Add("성적"); // chart의 타이틀 : 성적

            // Random 클래스의 객체 r 생성
            Random r = new Random(); 

            // 시리즈에 10개의 데이터를 넣어 차트로 출력 
            for (int i = 0; i < 10; i++)
            {
                chart1.Series[0].Points.Add(r.Next(101));
            }
            // 범례 : 비주얼\n 프로그래밍
            chart1.Series[0].LegendText = "비주얼\n프로그래밍";
        }
    }
}
