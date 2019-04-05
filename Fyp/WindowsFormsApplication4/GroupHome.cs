using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class GroupHome : Form
    {
        public GroupHome()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Formation_Group frmgr = new Formation_Group();
            this.Hide();
            frmgr.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Groupinfo grinfo = new Groupinfo();
            this.Hide();
            grinfo.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Group_Project grpro = new Group_Project();
            this.Hide();
            grpro.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Project_Advisor proad = new Project_Advisor();
            this.Hide();
            proad.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AdvisorHome adv = new AdvisorHome();
            this.Hide();
            adv.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            AdvisorHome adv = new AdvisorHome();
            this.Hide();
            adv.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            StudenHome Peron = new StudenHome();
            this.Hide();
            Peron.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

            StudenHome Peron = new StudenHome();
            this.Hide();
            Peron.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ProjectHome pro = new ProjectHome();
            this.Hide();
            pro.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ProjectHome pro = new ProjectHome();
            this.Hide();
            pro.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            GroupHome group = new GroupHome();
            this.Hide();
            group.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            GroupHome group = new GroupHome();
            this.Hide();
            group.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            evaluationHome eva = new evaluationHome();
            this.Hide();
            eva.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            evaluationHome eva = new evaluationHome();
            this.Hide();
            eva.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Report2 rep = new Report2();
            this.Hide();
            rep.Show();
        }
    }
}
