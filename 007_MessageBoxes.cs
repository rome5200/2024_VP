using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _007_MessageBoxes // 교재 408p
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
            // MessageBox에 "안녕" 출력
            MessageBox.Show("안녕");

            // Hello 이름의 MessageBox에 "안녕하세요" 출력 
            MessageBox.Show("안녕하세요", "Hello");

            // yes와 no 버튼을 갖는 Question 이름의 MessageBox에
            // "두개의 버튼"을 보여준다
            MessageBox.Show("두개의 버튼", "Question", MessageBoxButtons.YesNo);

            // yes와 no, cancel 버튼과 물음표 아이콘을 갖는
            // Question 이름의 MessageBox에 
            // "세개의 버튼과 물음표"을 보여준다
            MessageBox.Show("세개의 버튼과 물음표", "Question",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            // 확인 버튼과 느낌표 아이콘을 갖는
            //  Title 이름의 MessageBox에 "느낌표와 알람"을 보여준다
            MessageBox.Show("느낌표와 알람", "Title", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);

            //단축키 : ctrl + K + C -> comment 만들기
            //단축키 : ctrl + K + U -> uncomment 만들기

            // yes와 no, cancel 버튼과 물음표 아이콘을 갖는
            // Question 이름의 MessageBox에
            // "세개의 버튼과 물음표"를 보여주고
            // 두번째 버튼을 디폴트로 지정한다.
            DialogResult result = MessageBox.Show("세개의 버튼과 물음표", "Question",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            // 같은 버튼이 여러 번 눌려도 오류X
            if (result == DialogResult.Yes) { }
            else if(result == DialogResult.No) { }
        }
    }
}
