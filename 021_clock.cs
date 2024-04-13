using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _021_clock
{
    public partial class Form1 : Form
    {
        /// 멤버변수(필드)
        Graphics g;
        bool aClock_Flag = true;
        Point center; // 중심점
        int radius; // 시계의 반지름
        int hourHand; // 시침의 길이
        int minHand; // 분침의 길이
        int secHand; // 초침의 길이

        const int clientSize = 300;
        const int clockSize = 200;

        Font fDate; // 날짜 폰트(dClockSetting() 에서 만들 것임)
        Font fTime; // 시간 폰트
        Brush bDate;  // 날짜 색깔
        Brush bTime;  // 시간 색깔

        Point panelCenter; // 패널 중심점

        public Form1() // 생성자
        {
            InitializeComponent();

            this.ClientSize
              = new Size(clientSize, clientSize + menuStrip1.Height);
            this.Text = "My Form Clock";

            panel1.Width = clockSize;
            panel1.Height = clockSize;

            panel1.Location = new Point(
              clientSize / 2 - clockSize / 2,
              clientSize / 2 - clockSize / 2 + menuStrip1.Height);

            panel1.BackColor = Color.WhiteSmoke;
            
            g = panel1.CreateGraphics(); // 그래픽 객체 생성

            aClockSetting(); // 아날로그 시계 세팅
            dClockSetting(); // 디지털 시계 세팅
            TimerSetting(); // 타이머 세팅

            panelCenter = new Point(clockSize / 2, clockSize / 2);
        }

        // 디지털 시계 세팅 메소드
        private void dClockSetting()
        {
            fDate = new Font("맑은 고딕", 12, FontStyle.Bold);
            fTime = new Font("맑은 고딕", 32,
              FontStyle.Bold | FontStyle.Italic);

            bDate = Brushes.OrangeRed;
            bTime = Brushes.SteelBlue;
        }

        // 타이머 세팅 메소드
        private void TimerSetting()
        {
            Timer t = new Timer();

            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        // 1초마다 한번씩 수행되는 Tick 이벤트 처리뉴
        private void 아날로그ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClock_Flag = true;

        }

        private void 디지털ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aClock_Flag = false;
        }

        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
