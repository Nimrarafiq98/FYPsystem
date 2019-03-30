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
    public partial class Formation_Group : Form
    {
        public Formation_Group()
        {
            InitializeComponent();
        }

        private void Formation_Group_Load(object sender, EventArgs e)
        {
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Select Students";
            chk.Name = "Select Students";

            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from Student", con);
            DataTable dtl = new DataTable();
            sqlda.Fill(dtl);
            dataGridView1.DataSource = dtl;
            dataGridView1.Columns.Add(chk);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "INSERT INTO [Group](Created_On)VALUES(('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data insert");


                con.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }


            String str1 = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(str1);
            con1.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if ((dataGridView1.Rows[i].Cells[2].Value) != null)
                {
                    if ((Boolean)dataGridView1.Rows[i].Cells[2].Value == true)
                    {
                        String query1 = "INSERT INTO GroupStudent (GroupId,StudentId,Status,AssignmentDate)VALUES((select MAX(Id) FROM [Group]),('" + dataGridView1.Rows[i].Cells[0].Value + "'),(Select Id from Lookup Where Lookup.Value = '" + comboBox1.Text + "'),('" + Convert.ToDateTime(dateTimePicker2.Text) + "'));";
                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.ExecuteNonQuery();
                    }


                }
            }
            MessageBox.Show("students selected for group");

        }
    }
}
