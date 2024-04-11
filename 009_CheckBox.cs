using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _009_CheckBox // 교재 414p
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
            // 문자열 checkSates를 공백으로 선언 
            string checkStates = "";

            // 체크박스 배열 cBox를 선언하고 5개의 체크박스로 초기화
            CheckBox[] cBox = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5 };

            // cBox의 각 요소에 대한 Text 속성과 Checked 속성을 문자열에 추가하고
            // 5개 체크박스의 Checked 상태 출력
            foreach(var item in cBox)
            {
                checkStates += string.Format("{0} : {1}\n", item.Text, item.Checked);
            }
            MessageBox.Show(checkStates, "checkStates");

            // 좋아하는 과일만 표시하는 summary 문자열을 선언하고 초기화
            string summary = "좋아하는 과일은 : ";

            // cBox 배열의 각 요소의 Checked 속성을 검사하여 true인 것만 summery에 추가하고
            // 메세지박스에 summary 문자열 출력
            foreach(var item in cBox)
            {
                if (item.Checked == true)
                    summary += item.Text + " ";
            }
            MessageBox.Show(summary, "summary");
        }
    }
}
