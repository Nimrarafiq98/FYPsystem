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
    public partial class Project_Advisor : Form
    {
        public Project_Advisor()
        {
            InitializeComponent();
        }

        private void Project_Advisor_Load(object sender, EventArgs e)
        {
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

            String query = "select Firstname from Person join Advisor on Person.Id = Advisor.Id;";

            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader Reader;




            con.Open();

            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {

                comboBox2.Items.Add(Reader.GetString(0));


            }

            String query1 = "select Title from Project";

            SqlConnection con1 = new SqlConnection(str);

            SqlCommand cmd1 = new SqlCommand(query1, con1);
            SqlDataReader Reader1;




            con1.Open();

            Reader1 = cmd1.ExecuteReader();
            while (Reader1.Read())
            {

                comboBox1.Items.Add(Reader1.GetString(0));


            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                String query = "INSERT INTO ProjectAdvisor (AdvisorId,ProjectId,AdvisorRole,AssignmentDate)VALUES((select Id from Person where Person.FirstName = '"+comboBox2.Text+ "'),(select Id from Project where Project.Title = '" + comboBox1.Text + "'),(select Id from Lookup where Lookup.Value ='" + comboBox3.Text + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";

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
