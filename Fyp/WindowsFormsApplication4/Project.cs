﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication4
{
    public partial class Project : Form
    {
        public Project()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                String query = "INSERT INTO Project (Description,Title)VALUES(('" + (textBox1.Text).ToString() + "'),('" + (textBox2.Text).ToString() + "'));";

                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show("Data insert");
           
                con.Close();

                ProjectShow sho = new ProjectShow();
                this.Hide();
                sho.Show();
            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }
        }
    }
}
