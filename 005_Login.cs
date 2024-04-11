using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _005_Login // 교재 419p
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Button Click 이벤트 처리 함수
        private void btnBMI_Click(object sender, EventArgs e)
        {    
            // 아이디가 abcd이고 패스워드가 1234일 경우
            // txtResult에 로그인 성공이라고 출력
            if (txtID.Text == "abcd" && txtPW.Text == "1234")
            {
                txtResult.Text = "로그인 성공";
            }
            // 아닐 경우 txtResult에 로그인 실패라고 출력
            else
            {
                txtResult.Text = "로그인 실패";
            }
        }
    }
}
