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
        //kkkkkjkejjjjj
        private void button1_Click(object sender, EventArgs e)
        {
try

            {
                
                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                String query = "INSERT INTO Person (FirstName,LastName,Contact,Email,DateOfBirth,Gender)VALUES(('" + (textBox2.Text).ToString() + "'),('" + (textBox3.Text).ToString() + "'),('" + (textBox4.Text).ToString() + "'),('" + (textBox5.Text).ToString() + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'),(select Id from Lookup where Lookup.Value ='"+comboBox1.Text+"'));";

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

        private void button2_Click(object sender, EventArgs e)
        {
            try

            {

                //    String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                //    String query = "INSERT INTO Person (FirstName,LastName,Contact,Email,DateOfBirth,Gender)VALUES(('" + (textBox2.Text).ToString() + "'),('" + (textBox3.Text).ToString() + "'),('" + (textBox4.Text).ToString() + "'),('" + (textBox5.Text).ToString() + "'),('" + Convert.ToDateTime(dateTimePicker1.Text) + "'),(select Id from Lookup where Lookup.Value ='" + comboBox1.Text + "'));";

                //    SqlConnection con = new SqlConnection(str);

                //    SqlCommand cmd = new SqlCommand(query, con);

                //    con.Open();

                //    cmd.ExecuteNonQuery();

                //    MessageBox.Show("Data insert");
                //    Advisor Info = new Advisor();
                //    this.Hide();
                //    Info.Show();

                //    con.Close();
                infoStudent show = new infoStudent();
                this.Hide();
                show.Show();

            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";

                String query = "SELECT * from Lookup;";
               
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader Reader;




                 con.Open();

                Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                   
                    comboBox1.Items.Add(Reader.GetString(2));
                    

                }
            

            }

        private void button3_Click(object sender, EventArgs e)
        {
            //comboBox1.Show();
        }
    }
    }

