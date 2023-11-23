using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf.Facades;
using System.Runtime.InteropServices.ComTypes;

namespace Chrimilikasu
{
    internal class PdfDocumenter
    {
        private readonly string pdfFilePath = "";
        private readonly string saveDirectoryPath = "";

        public string PdfFilePath { get { return pdfFilePath; } }
        public string SaveDirectoryPath { get { return saveDirectoryPath; } }
        public PdfDocumenter(string pdfFilePath, string saveDirectoryPath)
        {
            this.pdfFilePath = pdfFilePath;
            this.saveDirectoryPath = saveDirectoryPath;
        }
        public void ConvertToPng(int start = 0, int end = 99999)
        {
            //// load PDF with an instance of Document                        
            //var document = new Document(this.PdfFilePath);

            // instantiate PdfConverter
            PdfConverter converter = new PdfConverter();
            // Bind input pdf file
            converter.BindPdf(this.PdfFilePath);
            // Initialize the converting process
            converter.DoConvert();
            converter.StartPage = 5;

            // 無料版は4ページまでしかできない
            var idx = 0;
            while (converter.HasNextImage())
            {
                var saveFIlePath = $"{this.saveDirectoryPath}png{idx}.png";
                converter.GetNextImage(saveFIlePath, System.Drawing.Imaging.ImageFormat.Png);
                idx++;
            }

            // Close the PdfConverter object
            converter.Close();
        }
    }
}
