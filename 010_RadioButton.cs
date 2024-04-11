using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _010_RadioButton // 교재 416p
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
            // 메시지박스에 표시할 문자열을 선언하고 빈 문자열로 초기화
            string result = "";

            // 국적 그룹박스에 있는 4개의 라디오버튼의 Checked 상태를 점검하여
            // 체크된 국적을 문자열에 추가
            if (rbkorea.Checked)
                result += "국적 : 대한민국\n";
            else if (rbChina.Checked)
                result += "국적 : 중국\n";
            else if (rbJapan.Checked)
                result += "국적 : 일본\n";
            else if (rbOthers.Checked)
                result += "국적 : 그 외 국가\n";
            
            // 성별 그룹박스에 있는 2개의 라디오버튼 중
            // checkedRB로 설정된 것의 성별을 문자열에 추가
            if (rbMale.Checked) // if (checkedRB == rbMale)
                result += "성별 : 남성";
            else if (rbFemale.Checked) // if (checkedRB == rbFemale)
                result += "성별 : 여성";

            // 메시지박스에 출력
            MessageBox.Show(result, "국적/성별");
        }
    }
}
