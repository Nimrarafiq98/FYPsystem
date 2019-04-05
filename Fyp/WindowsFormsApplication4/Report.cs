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
    public partial class Report : Form
    {
        public Report()
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
        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                String str = "Data Source=HAIER-PC\\NIMRASQLSERVER;Initial Catalog=ProjectA;Integrated Security=True";
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT CONCAT(p.FirstName,' ' , p.LastName) as [Name], s.RegistrationNo, B.[Value] as [Status],  e.[Name] as Evaluation_Name,ge.ObtainedMarks, e.TotalMarks, e.TotalWeightage, pr.Title as Project_Title, pr.[Description] as Project_Description FROM Person as p JOIN Student as s ON p.Id = s.Id JOIN GroupStudent as gs ON s.Id = gs.StudentId JOIN GroupEvaluation as ge ON ge.GroupId = gs.GroupId JOIN Evaluation as  e ON ge.EvaluationId = e.Id JOIN GroupProject as gp ON gs.GroupId = gp.GroupId JOIN Project as pr ON gp.ProjectId=pr.Id LEFT JOIN Lookup AS B ON (B.Id = gs.Status  ) ; ", con);
                DataTable dtl = new DataTable();
                sqlda.Fill(dtl);
                dataGridView1.DataSource = dtl;
            }

            catch (Exception es)

            {

                MessageBox.Show(es.Message);



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            exportgridtopdf(dataGridView1, "test");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
