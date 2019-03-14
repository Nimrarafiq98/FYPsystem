using System;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

            panel1.Hide();
            DataGridViewButtonColumn chk = new DataGridViewButtonColumn();
            chk.HeaderText = "Edit";
            chk.Name = "Edit Advisor";
            DataGridViewButtonColumn chk1 = new DataGridViewButtonColumn();
            chk1.HeaderText = "Delete";
            chk1.Name = "Delete Advisor";
            chk.Text = "Update";
            chk1.Text = "Delete";
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from Advisor", con);

            DataTable dtl = new DataTable();
            sqlda.Fill(dtl);
            dataGridView1.DataSource = dtl;
            dataGridView1.Columns.Add(chk);
            dataGridView1.Columns.Add(chk1);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //label1.Show();
                //label2.Show();
                //label3.Show();
                //textBox1.Show();
                //textBox2.Show();
                //comboBox1.Show();
                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    String query = "Delete from Advisor where Id = '" + row.Cells[0].Value + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Advisor is deleted");
                    Form3 ne = new Form3();
                    this.Hide();
                    ne.Show();
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    //Edit_Advisor edit = new Edit_Advisor();
                    panel1.Show();
                    textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboBox1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //edit.Show();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Advisor ad = new Advisor();
            this.Hide();
            ad.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = Convert.ToInt32(textBox1.Text);
                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "Update Advisor Set Designation = (select Id from Lookup where Lookup.Value ='" + comboBox1.Text + "'),Salary=('" + Convert.ToDecimal(textBox2.Text) + "')where Id = '" + Convert.ToInt32(textBox1.Text) + "';";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");


                con.Close();
                panel1.Hide();
                Form3 ne = new Form3();
                this.Hide();
                ne.Show();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
