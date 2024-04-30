using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _025_SensorMonitoring
{
    public partial class Form1 : Form
    {
        SerialPort sPort = null;
        private double xCount = 200;
        //List<SensorData> myData = new List<SensorData;
        
        //시뮬레이션을 위한 타이머와 랜덤 선언
        Timer t = new Timer();
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();

            foreach (var ports in SerialPort.GetPortNames())
                comboBox1.Items.Add(ports);
            comboBox1.Text = "Select Port";

            progressBar1.Minimum = 0; progressBar1.Maximum = 1023;

            ChartSetting();
            InitSetting();
        }

        private void ChartSetting()
        {
            //chart1과 chart2 타이틀 설정
            chart1.Titles.Add("조도");
            chart2.Titles.Add("온도/습도");

            ////chart1 설정 - 빌드 오류로 인해 주석처리
            //chart1.ChartAreas.Clear();
            //chart1.ChartAreas.Add("lumi");

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = xCount;
            chart1.ChartAreas[0].AxisX.Interval = xCount / 4;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 800;
            chart1.ChartAreas[0].AxisY.Interval = 200;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart1.ChartAreas[0].BackColor = Color.Black;

            //chart2 설정
            chart2.Series.Clear();
            chart2.Series.Add("temp");
            chart2.Series.Add("humi");

            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Maximum = 200;
            chart2.ChartAreas[0].AxisX.Interval = 50;
            chart2.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart2.ChartAreas[0].AxisY.Minimum = 0;
            chart2.ChartAreas[0].AxisY.Maximum = 100;
            chart2.ChartAreas[0].AxisY.Interval = 20;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chart2.ChartAreas[0].BackColor = Color.Black;

            //chart1의 Series 디자인
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.LightGreen;
            chart1.Series[0].BorderWidth = 2;

            ////chart2의 Series 디자인
            //chart2.Series[0].ChartType = SeriesChartType.Line;
            //chart2.Series[0].Color = Color.LightBlue;
            //chart2.Series[0].BorderWidth = 2;

            //chart2.Series[1].ChartType = SeriesChartType.Line;
            //chart2.Series[1].Color = Color.Orange;
            //chart2.Series[1].BorderWidth = 2;
        }

        private void InitSetting()
        {
            btnPortvalue.BackColor = Color.Blue;
            btnPortvalue.ForeColor = Color.White;
            btnPortvalue.Text = "";
            btnPortvalue.Font = new Font("맑은 고딕", 12, FontStyle.Bold);

            lblConnectionTime.Text = "Connection Time : ";
            textBox1.TextAlign = HorizontalAlignment.Center;
            btnConnect.Enabled = false;
            btnDisconnect.Enabled = false;
        }

        private void 시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += T_Tick;
            t.Start();
        }

        private void T_Tick(object sender, EventArgs e)
        {
            int value = r.Next(1024);
            ShowValue(value.ToString());
        }

        private void ShowValue(string v)
        {
            //string[] subStr = new string[3] { string.Empty, string.Empty, string.Empty };
            listBox1.Items.Add(DateTime.Now.ToString() + "  >>\t" + v);
            progressBar1.Value = int.Parse(v);
            chart1.Series[0].Points.Add(int.Parse(v));
        }
    }
}
