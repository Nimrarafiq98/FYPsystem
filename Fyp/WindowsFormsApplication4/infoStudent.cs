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
    public partial class infoStudent : Form
    {
        public infoStudent()
        {
            InitializeComponent();
        }

        private void infoStudent_Load(object sender, EventArgs e)
        {
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
            SqlDataAdapter sqlda = new SqlDataAdapter("Select Person.Id,Student.RegistrationNo,Person.FirstName,Person.LastName,Person.Contact,Person.DateOfBirth,Person.Email,Person.Gender from Student join Person on Student.Id =Person.Id;", con);

            DataTable dtl = new DataTable();
            sqlda.Fill(dtl);
            dataGridView1.DataSource = dtl;
            dataGridView1.Columns.Add(chk);
            dataGridView1.Columns.Add(chk1);


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
                if (e.RowIndex >= 0 && e.ColumnIndex == 9)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    String query = "Delete from Student where Id = '" + row.Cells[0].Value + "';";
                    String query1 = "Delete from Person where Id = '" + row.Cells[0].Value + "';";
                    String query2 = "Delete from GroupStudent where StudentId = '" + row.Cells[0].Value + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand(query1, con);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand(query2, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Student is deleted");
                    String str1 = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                    SqlConnection con1 = new SqlConnection(str1);
                    con1.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("Select Person.Id,Student.RegistrationNo,Person.FirstName,Person.LastName,Person.Contact,Person.DateOfBirth,Person.Email,Person.Gender from Student join Person on Student.Id =Person.Id;", con1);

                    DataTable dtl1 = new DataTable();
                    sqlda.Fill(dtl1);
                    dataGridView1.DataSource = dtl1;

                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    Editstudent edit = new Editstudent();
                    edit.textBox5.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    edit.textBox1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    edit.textBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    edit.textBox3.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    edit.textBox4.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                   edit.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    edit.comboBox1.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    edit.Show();
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
