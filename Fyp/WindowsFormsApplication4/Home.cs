﻿using System;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
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

        private void label7_Click(object sender, EventArgs e)
        {
            GroupHome group = new GroupHome();
            this.Hide();
            group.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
