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
    public partial class Groupinfo : Form
    {
        public Groupinfo()
        {
            InitializeComponent();
        }

        private void Groupinfo_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn chk = new DataGridViewButtonColumn();
            chk.HeaderText = "Edit";
            chk.Name = "Edit Group";
            DataGridViewButtonColumn chk1 = new DataGridViewButtonColumn();
            chk1.HeaderText = "Delete";
            chk1.Name = "Delete Group";
            chk.Text = "Update";
            chk1.Text = "Delete";
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("select * from GroupStudent;", con);

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
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            if (e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                String query2= "Delete from GroupProject where GroupId = '" + row.Cells[0].Value + "';";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.ExecuteNonQuery();
                String query = "Delete from GroupStudent where GroupId = '" + row.Cells[0].Value + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                String query1 = "Delete from [Group] where Id = '" + row.Cells[0].Value + "';";
                SqlCommand cmd1 = new SqlCommand(query1, con);

                cmd1.ExecuteNonQuery();

                MessageBox.Show("Group is deleted");

                GroupHome grhm = new GroupHome();
                this.Hide();
                grhm.Show();

            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                EditGroup edit = new EditGroup();
                //panel1.Show();
               
                edit.textBox1.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
               
                edit.dateTimePicker1.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
               edit. comboBox1.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
                this.Hide();
                edit.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GroupHome grhm = new GroupHome();
            this.Hide();
            grhm.Show();
        }
    }
}
