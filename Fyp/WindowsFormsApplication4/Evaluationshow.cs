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
    public partial class Evaluationshow : Form
    {
        public Evaluationshow()
        {
            InitializeComponent();
        }

        private void Evaluationshow_Load(object sender, EventArgs e)
        {
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
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from Evaluation", con);

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
                if (e.RowIndex >= 0 && e.ColumnIndex == 5)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    String query = "Delete from Evaluation where Id = '" + row.Cells[0].Value + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Evaluation Record is deleted");
                    String str1 = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                    SqlConnection con1 = new SqlConnection(str1);
                    con1.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("select * from Evaluation", con1);

                    DataTable dtl1 = new DataTable();
                    sqlda.Fill(dtl1);
                    dataGridView1.DataSource = dtl1;

                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    editevaluation edit = new editevaluation();
                    edit.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    edit.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    edit.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    edit.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

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
