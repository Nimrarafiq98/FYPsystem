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
    public partial class Edit_Advisor : Form
    {
        public Edit_Advisor()
        {
            InitializeComponent();
        }

        private void Edit_Advisor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int key = Convert.ToInt32(    textBox1.Text);
                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "Update Advisor Set Designation = (select Id from Lookup where Lookup.Value ='" + comboBox1.Text + "'),Salary=('" + Convert.ToDecimal(textBox2.Text) + "')where Id = '" + Convert.ToInt32(textBox1.Text) + "';";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");


                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}