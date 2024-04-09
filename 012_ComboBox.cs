using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace _012_ComboBox1
{
    public partial class Form1 : Form
    {
        TextBox[] titles;
        ComboBox[] crds;
        ComboBox[] grds;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double totalScore = 0;
            int totalCredits = 0;
            for (int i = 0; i < crds.Length; i++)
            {
                if (titles[i].Text != "")
                {
                    int crd = int.Parse(crds[i].SelectedItem.ToString());
                    totalCredits += crd;
                    totalScore += crd * GetGrade(grds[i].SelectedItem.ToString());
                }
            }
            txtGrade.Text = ( totalScore / totalCredits ).ToString("0.00");
        }

        private double GetGrade(string v)
        {
            double grade = 0;

            if (v == "A+") grade = 4.5;
            else if (v == "A0") grade = 4.0;
            else if (v == "B+") grade = 3.5;
            else if (v == "B0") grade = 3.0;
            else if (v == "C+") grade = 2.5;
            else if (v == "C0") grade = 2.0;
            else if (v == "D+") grade = 1.5;
            else if (v == "D0") grade = 1.0;
            else grade = 0;

            return grade;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txt1.Text = "인체의 구조와 기능I";
            txt2.Text = "일반수학I";
            txt3.Text = "전기전자공학 및 실험";
            txt4.Text = "데이터사이언스";
            txt5.Text = "비주얼프로그래밍";
            txt6.Text = "설계 및 프로젝트 기본I";
            txt7.Text = "영어I";
            txt8.Text = "의사소통장애의 이해";

            crds = new ComboBox[] { crd1, crd2, crd3, crd4, crd5, crd6, crd7, crd8 };
            grds = new ComboBox[] { grd1, grd2, grd3, grd4, grd5, grd6, grd7, grd8 };
            titles = new TextBox[] { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8 };
            int[] arrCredit = { 1, 2, 3, 4, 5 };
            List<string> lstGrade = new List<string> { "A+", "A0", "B+", "B0", "C+", "C0", "D+", "D0", "F" };

            foreach (var combo in crds)
            {
                foreach (var i in arrCredit)
                    combo.Items.Add(i);
                combo.SelectedItem = 3;
            }

            foreach (var cb in grds)
            {
                foreach (var gr in lstGrade)
                    cb.Items.Add(gr);
            }
        }
    }
}
