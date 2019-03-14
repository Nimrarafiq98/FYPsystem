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
    public partial class ProjectShow : Form
    {
        public ProjectShow()
        {
            InitializeComponent();
        }

        private void ProjectShow_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            DataGridViewButtonColumn chk = new DataGridViewButtonColumn();
            chk.HeaderText = "Edit";
            chk.Name = "Edit Student";
            chk.Text = "Edit";

            DataGridViewButtonColumn chk1 = new DataGridViewButtonColumn();
            chk1.HeaderText = "Delete";
            chk1.Name = "Delete Student";

            chk1.Text = "Delete";

            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select Id,Description,Title from Project;", con);

            DataTable dtl = new DataTable();
            sqlda.Fill(dtl);
            dataGridView1.DataSource = dtl;
            dataGridView1.Columns.Add(chk);
            dataGridView1.Columns.Add(chk1);

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    String query = "Delete from Project where Id = '" + row.Cells[0].Value + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                   
                    MessageBox.Show("Project is deleted");
                    ProjectShow ne = new ProjectShow();
                    this.Hide();
                    ne.Show();


                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 3)
                {
                    //Editproject edit = new Editproject();
                    //edit.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    //edit.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    //edit.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();

                    //edit.Show();
                    panel1.Show();
                    textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                   




                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Project newpro = new Project();
            this.Hide();
            newpro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = Convert.ToInt32(textBox1.Text);
                String str1 = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "Update Project Set Description = ('" + textBox2.Text.ToString() + "'),  Title=('" + textBox3.Text.ToString() + "')where Id = '" + Convert.ToInt32(textBox1.Text) + "';";
                SqlConnection con1 = new SqlConnection(str1);
                SqlCommand cmd1 = new SqlCommand(query, con1);
                con1.Open();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Data Updated");


                con1.Close();
              
                ProjectShow ne = new ProjectShow();
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
