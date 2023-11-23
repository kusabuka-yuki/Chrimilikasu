using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using AnotherProgramProcess;

namespace Chrimilikasu
{
    public class TextDocumentReader
    {
        private const string tessDataPath = @"C:\Users\Yuki\AppData\Local\Programs\Tesseract-OCR\tessdata";
        public string pythonInterpreterPath = @"C:\Users\Yuki\AppData\Local\Programs\Python\Python37\python.exe";
        public string pythonScriptPath = @"G:\マイドライブ\ドライブ\IT系\GitHub\Tokium\OutputClipBoardImageDuringCharacter\app\main.py";
        public string saveImageName = @"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\output\p5_R_Tel3.png";
        internal string ImagePath { get; private set; }
        public TextDocumentReader(string imagePath) 
        {
            this.ImagePath = imagePath;
        }
        public string GetImageDuringCharacter()
        {
            //using(var tesseract = new Tesseract.TesseractEngine(tessDataPath, "jpn"))
            //{
            //    // OCRの実行
            //    Tesseract.Page page = tesseract.Process(Image);
            //    return page.GetText();
            //}

            //var txt = string.Empty;
            //using (var engine = new TesseractEngine(tessDataPath, "jpn", EngineMode.Default))
            //{
            //    using (var img = Pix.LoadFromFile(this.ImagePath))
            //    {
            //        using (var page = engine.Process(img))
            //        {
            //            txt = page.GetText();
            //        }
            //    }
            //}
            // pythonのプログラムを呼び出す。
            var pythonProcess = new PythonProcess(pythonInterpreterPath, pythonScriptPath);
            var args = new List<string> { this.ImagePath };
            // スクリーンショットの画像から文字列を読み込む
            pythonProcess.StartProcess(args);
            // 戻り値を返す。
            return pythonProcess.GetStandardOutput("\n");
        }
    }
}

