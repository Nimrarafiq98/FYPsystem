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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //kkkkkjke
        private void button1_Click(object sender, EventArgs e)
        {
try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                String query = "INSERT INTO Person (FirstName,LastName,Contact,Email,DateOfBirth,Gender)VALUES(('" + (textBox2.Text).ToString() + "'),('" + (textBox3.Text).ToString() + "'),('" + (textBox4.Text).ToString() + "'),('" + (textBox5.Text).ToString() + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'),('" + Convert.ToInt32(textBox7.Text) + "'));";

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
        }
    }
}
