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
    public partial class Advisor : Form
    {
        public Advisor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "INSERT INTO Advisor (Id,Designation,Salary)VALUES((select MAX(Id) FROM Person),(select Id from Lookup where Lookup.Value ='" + comboBox1.Text + "'),('"+Convert.ToDecimal(textBox1.Text)+"'));";
                 SqlConnection con = new SqlConnection(str);
                 SqlCommand cmd = new SqlCommand(query, con);
                  con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data insert");
                Student Info = new Student();
                this.Hide();
                Info.Show();

                con.Close();

            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }


        }
    }
}
