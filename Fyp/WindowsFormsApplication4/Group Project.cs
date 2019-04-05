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
    public partial class Group_Project : Form
    {
        public Group_Project()
        {
            InitializeComponent();
        }

        private void Group_Project_Load(object sender, EventArgs e)
        {
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

            String query = "select Title from Project;";

            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader Reader;




            con.Open();

            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {

                comboBox1.Items.Add(Reader.GetString(0));


            }

            String query1 = "select Id from [Group]";

            SqlConnection con1 = new SqlConnection(str);

            SqlCommand cmd1 = new SqlCommand(query1, con1);
            SqlDataReader Reader1;




            con1.Open();

            Reader1 = cmd1.ExecuteReader();
            while (Reader1.Read())
            {

                comboBox2.Items.Add(Reader1.GetInt32(0));


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                String query = "INSERT INTO GroupProject (ProjectId,GroupId,AssignmentDate)VALUES((select Id from Project where Project.Title = '" + comboBox1.Text + "'),(select Id from [Group] where [Group].Id= '" + comboBox2.Text + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";

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

        private void button2_Click(object sender, EventArgs e)
        {
            GroupHome GRHM = new GroupHome();
            this.Hide();
            GRHM.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Project_Advisor PRAD = new Project_Advisor();
            this.Hide();
            PRAD.Show();
        }
    }
    }

