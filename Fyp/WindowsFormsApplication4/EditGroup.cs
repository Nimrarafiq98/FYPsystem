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
    public partial class EditGroup : Form
    {
        public EditGroup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(textBox1.Text);
            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            String query = "Update GroupStudent Set AssignmentDate=('" + Convert.ToDateTime(dateTimePicker1.Text) + "'), Status=(select Id from Lookup where Lookup.Value ='" + comboBox1.Text + "') where GroupId = '" + Convert.ToInt32(textBox1.Text) + "';";
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data Updated");
            con.Close();

            GroupHome grhm = new GroupHome();

            this.Hide();
            grhm.Show();
        }
    }
}
