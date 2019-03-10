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
    public partial class StudentShow : Form
    {
        public StudentShow()
        {
            InitializeComponent();
        }

        private void StudentShow_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                if ((dataGridView1.Rows[i].Cells[2].Value) != null)
                {
                    if ((Boolean)dataGridView1.Rows[i].Cells[2].Value == true)
                    {
                        String query = "INSERT INTO GroupStudent (GroupId,StudentId,Status,AssignmentDate)VALUES((select MAX(Id) FROM [Group]),('" + dataGridView1.Rows[i].Cells[0].Value + "'),(Select Id from Lookup Where Lookup.Value = '" + comboBox1.Text + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                    }


                }
            }
            MessageBox.Show("students selected for group");
        }
    }
}
