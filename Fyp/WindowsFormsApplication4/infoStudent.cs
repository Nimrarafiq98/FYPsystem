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
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    cmd1.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand(query1, con);
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("Student is deleted");
                    StudenHome ne = new StudenHome();
                    this.Hide();
                    ne.Show();


                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 8)
                {
                    //Editstudent edit = new Editstudent();
                    panel1.Show();
                    textBox5.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox2.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox3.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox4.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    comboBox1.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
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
            Person ne = new Person();
            this.Hide();
            ne.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = Convert.ToInt32(textBox5.Text);
                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "Update Person Set  FirstName=('" + textBox1.Text.ToString() + "'),LastName=('" + textBox2.Text.ToString() + "'),Contact=('" + textBox3.Text.ToString() + "'),Email=('" + textBox4.Text.ToString() + "'),DateOfBirth=('" + Convert.ToDateTime(dateTimePicker1.Text) + "'),Gender=(select Id from Lookup where Lookup.Value ='" + comboBox1.Text + "') where Id = '" + Convert.ToInt32(textBox5.Text) + "';";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
                con.Close();
                panel1.Hide();
                StudenHome ne = new StudenHome();
                this.Hide();
                ne.Show();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
               
          


        }

        private void cmdInfo_Click(object sender, EventArgs e)
        {
        }
    }
}
