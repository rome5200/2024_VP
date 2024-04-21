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
        int minHand; // 분침
        int secHand; // 초침

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
            g = panel1.CreateGraphics();

            aClockSetting();
            dClockSetting();
            TimerSetting();

            panelCenter = new Point(clockSize / 2, clockSize / 2);
        }

        private void dClockSetting()
        {
            fDate = new Font("맑은 고딕", 12, FontStyle.Bold);
            fTime = new Font("맑은 고딕", 32,
              FontStyle.Bold | FontStyle.Italic);

            bDate = Brushes.OrangeRed;
            bTime = Brushes.SteelBlue;
        }

        private void TimerSetting()
        {
            Timer t = new Timer();

            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            DateTime c = DateTime.Now;

            panel1.Refresh();

            if (aClock_Flag) //아날로그 시계
            {
                DrawClockFace();

                // 시간에 따른 시계 바늘들의 각도를 계산
                double radHr = (c.Hour % 12 + c.Minute / 60.0) * 30
                  * Math.PI / 180;
                double radMin = (c.Minute + c.Second / 60.0) * 6
                  * Math.PI / 180;
                double radSec = c.Second * 6 * Math.PI / 180;

                DrawHands(radHr, radMin, radSec);
            }
            else // 디지털 시계
            {
                string date = DateTime.Today.ToString("D");
                string time = string.Format("{0:D2}:{1:D2}:{2:D2}",
                    c.Hour, c.Minute, c.Second);

                g.DrawString(date, fDate, bDate, new Point(10, 70));
                g.DrawString(time, fTime, bTime, new Point(10, 90));

            }
        }

        // 시계바늘 그리기
        private void DrawHands(double radHr, double radMin, double radSec)
        {
            // 시침
            DrawLine(0, 0,
              (int)(hourHand * Math.Sin(radHr)),
              (int)(hourHand * Math.Cos(radHr)),
              Brushes.RoyalBlue, 8);

            // 분침
            DrawLine(0, 0,
             (int)(minHand * Math.Sin(radMin)),
             (int)(minHand * Math.Cos(radMin)),
             Brushes.SkyBlue, 6);

            // 초침
            DrawLine(0, 0,
             (int)(secHand * Math.Sin(radSec)),
             (int)(secHand * Math.Cos(radSec)),
             Brushes.OrangeRed, 4);

            // 배꼽
            int coreSize = 16;
            Rectangle r = new Rectangle(panelCenter.X - coreSize / 2,
              panelCenter.Y - coreSize / 2, coreSize, coreSize);
            g.FillEllipse(Brushes.Gold, r);
            g.DrawEllipse(new Pen(Brushes.Green, 3), r);
        }

        private void DrawLine(int x1, int y1, int x2, int y2,
          Brush brush, int thick)
        {
            Pen p = new Pen(brush, thick);
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            //Point panelCenter = new Point(clockSize/2, clockSize/2);

            g.DrawLine(p, panelCenter.X + x1, panelCenter.Y + y1,
              panelCenter.X + x2, panelCenter.Y - y2);
        }

        // 시계판 그리기
        private void DrawClockFace()
        {
            const int penWidth = 30; // 시계 테두리 선의 두께

            Pen p = new Pen(Brushes.LightSteelBlue, penWidth);
            g.DrawEllipse(p, penWidth / 2, penWidth / 2,
              clockSize - penWidth, clockSize - penWidth);
        }

        private void aClockSetting()
        {
            center = new Point(clientSize / 2, clientSize / 2);
            radius = clockSize / 2;

            hourHand = (int)(radius * 0.45);
            minHand = (int)(radius * 0.55);
            secHand = (int)(radius * 0.65);
        }

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
