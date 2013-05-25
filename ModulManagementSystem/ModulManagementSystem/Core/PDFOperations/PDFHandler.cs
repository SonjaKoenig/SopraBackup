using iTextSharp.text;
using iTextSharp.text.pdf;
using ModulManagementSystem.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System;
using ModulManagementSystem.Core.DBOperations;

namespace ModulManagementSystem.Core.PDFOperations
{
    public class PDFHandler
    {
        private BaseFont bfTimes;
        private Font subjectTitleFont;
        private Font moduleTitleFont;
        private Font moduleDescriptionFont;
        private Font subTitleFont;
        private Font titleFont;
        private ArchiveLogic logic;
        private String pdfpath = "PDFs/";

        /// <summary>
        /// Constructor initialized fonts and logic
        /// </summary>
        public PDFHandler()
        {
            bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);            
            subjectTitleFont = new Font(bfTimes, 15, Font.ITALIC);
            moduleTitleFont = new Font(bfTimes, 13, Font.ITALIC);
            moduleDescriptionFont = new Font(bfTimes, 10, Font.ITALIC);
            subTitleFont = new Font(bfTimes, 14, Font.ITALIC);
            titleFont = new Font(bfTimes, 20, Font.ITALIC);
            logic = new ArchiveLogic();
        }
            
        public void CreatePDF(Modul modul, HttpServerUtility server)
        {
            Modulhandbook modulhandbook = GetModulhandbook(modul);
            List<ModulPartDescription> modulpartdescriptions = modul.Descriptions.ToList<ModulPartDescription>();
            
            ArchiveLogic logic = new ArchiveLogic();

            var output = new FileStream(server.MapPath("PDFs/" +logic.getNameFromModule(modul) +".pdf"), FileMode.Create);
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();

            //add stuff...
            try
            {                
                Image logo1 = Image.GetInstance(server.MapPath("Images/UniLogo.gif"));
                logo1.ScaleAbsolute(150, 150);
                logo1.SetAbsolutePosition(40,675);
                Image logo2 = Image.GetInstance(server.MapPath("Images/UniTitle.gif"));
                logo2.ScaleAbsolute(250, 50);
                logo2.SetAbsolutePosition(300,690);
                document.Add(logo1);
                document.Add(logo2);
                for (int i = 0; i < 8; i++)
                {
                    document.Add(new Paragraph(" "));
                }

                Paragraph p1 = new Paragraph("Universität Ulm",titleFont);
                
                document.Add(p1);
                var p2 = new Paragraph(modulhandbook.Name);
                document.Add(p2);
                document.Add(new Paragraph("_________________________________________________________________________"));
                
                var p3 = new Paragraph(logic.getNameFromModule(modul), subTitleFont);
                document.Add(p3);
                for (int i = 0; i < 2; i++)
                {
                    document.Add(new Paragraph(" "));
                }

                foreach (ModulPartDescription m in modulpartdescriptions)
                {
                    document.Add(new Paragraph(" "));
                    document.Add(new Paragraph("             "+m.Name + "    :    " + m.Description,moduleDescriptionFont));
                    document.Add(new Paragraph("_________________________________________________________________________"));
                }
            }
            catch (Exception e)
            {
                string itgetused = e.ToString();
            }
            finally
            {
                document.Close();
            }
            openPdf(server.MapPath(pdfpath + logic.getNameFromModule(modul) + ".pdf"));
        }
        private Modulhandbook GetModulhandbook(Modul modul)
        {
            Subject subject=modul.Subjects.First();
            return subject.Modulhandbook;
        }

        /// <summary>
        /// writes a modulhandbook and its subjects and modules to a pdf and opens the pdf
        /// </summary>
        /// <param name="modulhandbook">should not me null</param>
        /// <param name="server">http server</param>
        public void WriteModulhandbookToPdf(Modulhandbook modulhandbook, HttpServerUtility server)
        {
            var output = new FileStream(server.MapPath(pdfpath + modulhandbook.Name + ".pdf"), FileMode.Create);
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();

            try
            {
                createTitlePage(modulhandbook, server, document);
                createIndex(modulhandbook, server, document);
                writeSubjectsToDoc(modulhandbook, document);
            }
            catch (Exception e)
            {
                throw new Exception("Das erstellen des Modulhandbuchs hat nicht geklappt mit folgender Fehlermelung: " + e.Message);
            }
            finally
            {
                document.Close();
            }

            openPdf(server.MapPath(pdfpath + modulhandbook.Name + ".pdf"));
        }

        public void CreateAndOpenSoubjectPdf(Subject subject, HttpServerUtility server)
        {
            var output = new FileStream(server.MapPath(pdfpath + subject.Name + ".pdf"), FileMode.Create);
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
            var writer = PdfWriter.GetInstance(document, output);
            document.Open();

            try
            {
                writeSubjectToDoc(document, 1, subject);
            }
            catch (Exception e)
            {
                throw new Exception("Das erstellen des Subjects hat nicht geklappt mit folgender Fehlermelung: " + e.Message);
            }
            finally
            {
                document.Close();
            }

            openPdf(server.MapPath(pdfpath + subject.Name + ".pdf"));
        }

        /// <summary>
        /// starts a process with the given filepath
        /// </summary>
        /// <param name="filepath">the data to execute</param>
        public void openPdf(String filepath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            process.StartInfo.FileName = filepath;
            process.Start();
        }

        private void writeSubjectsToDoc(Modulhandbook modulhandbook, Document document)
        {
            int subNo = 1;
            foreach (Subject s in modulhandbook.Subjects)
            {
                writeSubjectToDoc(document, subNo, s);
                subNo++;
            }
        }

        private void writeSubjectToDoc(Document document, int subNo, Subject s)
        {
            Paragraph p = new Paragraph(subNo.ToString() + " " + s.Name, subjectTitleFont);
            p.Alignment = 1;
            document.Add(p);

            writeModulesToDoc(document, subNo, s);
        }

        private void writeModulesToDoc(Document document, int subNo, Subject s)
        {
            int modulNo = 1;
            foreach (Modul m in s.Modules)
            {
                writeModulToDoc(document, subNo, modulNo, m);
                modulNo++;
            }
        }

        private void writeModulToDoc(Document document, int subNo, int modulNo, Modul m)
        {
            Paragraph p = new Paragraph(subNo.ToString() + "." + modulNo.ToString() + " " + logic.getNameFromModule(m), moduleTitleFont);
            p.Alignment = 1;
            document.Add(p);
            foreach (ModulPartDescription descr in m.Descriptions)
            {
                document.Add(new Paragraph(descr.Name + ":\t" + descr.Description, moduleDescriptionFont));
            }
            document.NewPage();
        }

        private void createIndex(Modulhandbook modulhandbook, HttpServerUtility server, Document document)
        {
            // need to create Index
        }

        private void createTitlePage(Modulhandbook modulhandbook, HttpServerUtility server, Document document)
        {
            addLogos(server, document);
            addEmptyParagraphs(document, 8);
            document.Add(new Paragraph("_________________________________________________________________________"));
            addEmptyParagraphs(document, 5);
            Paragraph p = new Paragraph("Modulhandbuch", subTitleFont);
            p.Alignment = 1; 
            document.Add(p);
            addEmptyParagraphs(document, 5);
            addTitle(modulhandbook, document);
            addEmptyParagraphs(document, 5);
            document.NewPage();
        }

        private void addTitle(Modulhandbook modulhandbook, Document document)
        {
            Paragraph p = new Paragraph(modulhandbook.Abschluss, titleFont);
            p.Alignment = 1;
            document.Add(p);
            p = new Paragraph(modulhandbook.Name, titleFont);
            p.Alignment = 1;
            document.Add(p);
            p = new Paragraph("(FSPO " + modulhandbook.FspoYear + ")", titleFont);
            p.Alignment = 1;
            document.Add(p);
        }

        private void addEmptyParagraphs(Document document, int number)
        {
            for (int i = 0; i < number; i++)
            {
                document.Add(new Paragraph(" "));
            }
        }

        private void addLogos(HttpServerUtility server, Document document)
        {
            Image logo;
            logo = Image.GetInstance(server.MapPath("Images/UniLogo.gif"));
            logo.ScaleAbsolute(150, 150);
            logo.SetAbsolutePosition(40, 675);
            document.Add(logo);
            logo = Image.GetInstance(server.MapPath("Images/UniTitle.gif"));
            logo.ScaleAbsolute(250, 50);
            logo.SetAbsolutePosition(300, 690);
            document.Add(logo);
        }
    }
}