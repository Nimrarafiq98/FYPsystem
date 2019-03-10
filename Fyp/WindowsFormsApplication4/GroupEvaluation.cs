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
    public partial class GroupEvaluation : Form
    {
        public GroupEvaluation()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GroupEvaluation_Load(object sender, EventArgs e)
        {
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

            String query = "select Id from [Group];";

            SqlConnection con = new SqlConnection(str);

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader Reader;




            con.Open();

            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {

                comboBox1.Items.Add(Reader.GetInt32(0));


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try

            {

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                String query = "INSERT INTO GroupEvaluation(GroupId,EvaluationId,ObtainedMarks,EvaluationDate)VALUES((select Id from [Group] where [Group].Id = '"+comboBox1.Text+"'),(select MAX(Id) from Evaluation),('"+Convert.ToInt32(textBox1.Text)+"'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'));";
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
