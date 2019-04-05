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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Report2 : Form
    {
        public Report2()
        {
            InitializeComponent();
        }
        public void exportgridtopdf(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;
            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);


            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";
            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdftable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }
        private void Report2_Load(object sender, EventArgs e)
        {

            String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("SELECT  Project.Title AS ProjectTitle,Project.Description AS ProjectDescription, C.Value AS AdvisorDesignation, B.Value AS AdvisorRole, ProjectAdvisor.AssignmentDate, G.Value AS[Status], s.RegistrationNo, CONCAT(P.FirstName,' ', P.LastName) as [Name] FROM Project JOIN ProjectAdvisor  ON Project.Id = ProjectAdvisor.ProjectId JOIN Advisor as ad ON ad.Id = ProjectAdvisor.AdvisorId JOIN GroupProject as gp ON gp.ProjectId = Project.Id JOIN GroupStudent as gs ON gs.GroupId = gp.GroupId JOIN Student as s ON s.Id = gs.StudentId JOIN Person as p ON p.Id = s.Id LEFT JOIN Lookup AS B ON(B.Id = ProjectAdvisor.AdvisorRole) LEFT JOIN Lookup AS C ON(C.Id = ad.Designation) LEFT JOIN Lookup AS G ON(G.Id = gs.[Status]);", con);

            DataTable dtl = new DataTable();
            sqlda.Fill(dtl);
            dataGridView1.DataSource = dtl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView1, "test");
        }
    }
}
