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
            Form3 adv = new Form3();
            this.Hide();
            adv.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            Form3 adv = new Form3();
            this.Hide();
            adv.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 Peron = new Form1();
            this.Hide();
            Peron.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 Peron = new Form1();
            this.Hide();
            Peron.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Project pro = new Project();
            this.Hide();
            pro.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Project pro = new Project();
            this.Hide();
            pro.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            this.Hide();
            group.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Evaluation eva = new Evaluation();
            this.Hide();
            eva.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            Evaluation eva = new Evaluation();
            this.Hide();
            eva.Show();
        }
    }
}