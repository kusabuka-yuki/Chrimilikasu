using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tesseract;
using AnotherProgramProcess;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Aspose.Pdf.Drawing;

namespace Chrimilikasu
{
    public partial class Form1 : Form
    {
        private const string pdfFilePath = "G:\\マイドライブ\\ドライブ\\クラウドワークス\\chrimilikatsu\\193.A12158E 山武農業(1999).pdf";
        private const string saveDirectoryPath = "G:\\マイドライブ\\ドライブ\\クラウドワークス\\chrimilikatsu\\png_output\\";

        private Dictionary<string, int> srcLeftRectangle = new Dictionary<string, int>()
        {
            { "x", 0},
            { "y", 0 },
            { "width", 1012 },
            {"height", 1434 },
        };
        private Dictionary<string, int> destLeftRectangle = new Dictionary<string, int>()
        {
            { "x", 0},
            { "y", 0 },
            { "width", 1012 },
            {"height", 1434 },
        };
        private Dictionary<string, int> srcRightRectangle = new Dictionary<string, int>()
        {
            { "x", 1043},
            { "y", 0 },
            { "width", 1012 },
            {"height", 1434 },
        };
        private Dictionary<string, int> destRightRectangle = new Dictionary<string, int>()
        {
            { "x", 0},
            { "y", 0 },
            { "width", 1012 },
            {"height", 1434 },
        };

        private Dictionary<string, int> srcRightTel1Rectangle = new Dictionary<string, int>()
        {
            { "x", 40},
            { "y", 165 },
            { "width", 170 },
            {"height", 460 },
        };
        private Dictionary<string, int> destRightTel1Rectangle = new Dictionary<string, int>()
        {
            { "x", 0},
            { "y", 0 },
            { "width", 270 },
            {"height", 560 },
        };

        private const string pythonInterpreterPath = @"C:\Users\Yuki\AppData\Local\Programs\Python\Python37\python.exe";
        private const string pythonScriptPath = @"G:\マイドライブ\ドライブ\IT系\GitHub\Tokium\OutputClipBoardImageDuringCharacter\app\main.py";
        private const string saveImageName = @"C:\Users\Yuki\Documents\tmp\OutputClipBoardImageDuringCharacter\oclpbdidgchtr.png";
        private const string imagePath = @"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\output\";
        private const string originImagePath = @"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\193.A12158E 山武農業(1999)";
        private const string targetOriginImgPathFmt = @"193.A12158E 山武農業(1999)-{0}.png";
        public const string outputFilePath = @"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\output\";

        private int Start { get; set; }
        private int End { get; set; }
        private Dictionary<string, Dictionary<CurrentReadTextImage.EReadColumn, string>> ReadedText {get;set;}
        private Dictionary<string, string> ReadedTexts { get; set; }
        // 左の画像(元)
        private RectangeInfos SrcLeftRectangle { get; set; }
        // 左の画像(先)
        private RectangeInfos DstLeftRectangle { get; set; }
        // 右の画像(元)
        private RectangeInfos SrcRightRectangle { get; set; }
        // 右の画像(先)
        private RectangeInfos DstRightRectangle { get; set; }
        // 左の氏名(元)
        private RectangeInfos SrcLeftName1Rectangle { get; set; }
        // 左の氏名(先)
        private RectangeInfos DstLeftName1Rectangle { get; set; }
        // 左の住所(元)
        private RectangeInfos SrcLeftAddress1Rectangle { get; set; }
        // 左の住所(先)
        private RectangeInfos DstLeftAddress1Rectangle { get; set; }
        // 左の電話番号(元)
        private RectangeInfos SrcLeftTel1Rectangle { get; set; }
        // 左の電話番号(先)
        private RectangeInfos DstLeftTel1Rectangle { get; set; }
        // 右の氏名(元)
        private RectangeInfos SrcRightName1Rectangle { get; set; }
        // 右の氏名(先)
        private RectangeInfos DstRightName1Rectangle { get; set; }
        // 右の住所(元)
        private RectangeInfos SrcRightAddress1Rectangle { get; set; }
        // 右の住所(先)
        private RectangeInfos DstRightAddress1Rectangle { get; set; }
        // 右の電話番号(元)
        private RectangeInfos SrcRightTel1Rectangle { get; set; }
        // 右の電話番号(先)
        private RectangeInfos DstRightTel1Rectangle { get; set; }

        public Form1()
        {
            InitializeComponent();
            //trial();
            SetRectangleInfos();
            //SplitImage(2,2);
            this.ReadedText = new Dictionary<string, Dictionary<CurrentReadTextImage.EReadColumn, string>>();
            this.ReadedTexts = new Dictionary<string, string>();
            //this.Start = 5;
            //this.End= 2;
            //SetReadText();

            // 画像を左右に2分割する。
            // サイズを少し大きくして保存する。
            // 全体からすべての文字を取得する。
            // 取得した文字をエクセルに出力する。
        }
        private void trial()
        {
            // 右の氏名(元)
            SrcRightName1Rectangle = new RectangeInfos(0, 120, 50, 360);
            // 右の氏名(先)
            DstRightName1Rectangle = new RectangeInfos(0, 0, 270, 360);
            var rightOutputPath = $"{outputFilePath}p{6}_R.png";
            var rightName1OutputPath = $"{outputFilePath}p{6}_R_Name{1}.png";
            var rightName1 = new Image(rightOutputPath, rightName1OutputPath);
            rightName1.Split2Part(this.SrcRightName1Rectangle.X, this.SrcRightName1Rectangle.Y,
                this.SrcRightName1Rectangle.W, this.SrcRightName1Rectangle.H,
                this.DstRightName1Rectangle.X, this.DstRightName1Rectangle.Y,
                this.DstRightName1Rectangle.W, this.DstRightName1Rectangle.H);
        }
        private void SetRectangleInfos()
        {
            // 左の画像(元)
            SrcLeftRectangle = new RectangeInfos(0, 0, 1012, 1434);
            // 左の画像(先)
            DstLeftRectangle = new RectangeInfos(0, 0, 1112, 1434);
            // 右の画像(元)
            SrcRightRectangle = new RectangeInfos(1043, 0, 1012, 1434);
            // 右の画像(先)
            //DstRightRectangle = new RectangeInfos(0, 0, 270, 1434);
            DstRightRectangle = new RectangeInfos(0, 0, 1112, 1434);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SetReadText()
        {
            var start = this.Start;
            var end = this.End;
            ReadText(start, end, "L");
            ReadText(start, end, "R");
        }
        private void ReadText(int start, int end, string leftRight)
        {
            for (int page = start; page <= end; page++)
            {
                var fName = $"p{page}_{leftRight}";

                var imgPath = $"{outputFilePath}{fName}.png";

                // ファイルの存在確認
                if (File.Exists(imgPath))
                {
                    var reader = new TextDocumentReader(imgPath);
                    var txt = reader.GetImageDuringCharacter();
                    this.ReadedTexts.Add(fName, txt);
                }
            }
        }
        private void TrialSetReadText()
        {
            var start = this.Start;
            var end = this.End;

            for (int page = start; page < end; page++)
            {
                // 氏名を読み込む
                var nameCrt = new CurrentReadTextImage(page, CurrentReadTextImage.EReadColumn.Name, imagePath);
                var nameCrtCollection = new CurrentReadTextImageCollection(nameCrt);
                this.ReadedText.Add(nameCrt.GetPageAndColumn(), nameCrtCollection.GetCollection(imagePath, @"*Name*"));
                // 住所を読み込む
                var addressCrt = new CurrentReadTextImage(page, CurrentReadTextImage.EReadColumn.Address, imagePath);
                var addressCrtCollection = new CurrentReadTextImageCollection(addressCrt);
                this.ReadedText.Add(addressCrt.GetPageAndColumn(), addressCrtCollection.GetCollection(imagePath, @"*Address*"));
                // 電話を読み込む
                var telCrt = new CurrentReadTextImage(page, CurrentReadTextImage.EReadColumn.Tel, imagePath);
                var telCrtCollection = new CurrentReadTextImageCollection(telCrt);
                this.ReadedText.Add(telCrt.GetPageAndColumn(), telCrtCollection.GetCollection(imagePath, @"*Tel*"));
            }
            //Console.WriteLine(this.ReadText);
        }
        private void OutputReadedText()
        {
            var outputPath = imagePath + "output.txt";
            using (var writer = new StreamWriter(outputPath, false))
            {
                var outputStr = string.Empty;
                foreach (var key in this.ReadedTexts.Keys)
                {
                    Console.WriteLine($"key: {key}");
                    outputStr = this.ReadedTexts[key].ToString();
                }
                writer.WriteLine(outputStr);
            }
        }
        /// <summary>
        /// 画像を分割する(不要)
        /// </summary>
        private void SplitImage(int start, int end)
        {
            //// 開始ページ番号を取得
            //// 終了ページ番号を取得

            ////1ページを2ページに分割
            ////var img = new Chrimilikasu.Image("");
            //var rTel1Img = new Chrimilikasu.Image(@"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\output\p5_L.png");
            //var x = srcRightTel1Rectangle["x"];
            //var y = srcRightTel1Rectangle["y"];
            //var width = srcRightTel1Rectangle["width"];
            //var height = srcRightTel1Rectangle["height"];
            //var dx = destRightTel1Rectangle["x"];
            //var dy = destRightTel1Rectangle["y"];
            //var dwidth = destRightTel1Rectangle["width"];
            //var dheight = destRightTel1Rectangle["height"];
            //var path = @"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\output\p5_R_tel1.png";

            //rTel1Img.Split2Part(x,y,width,height, dx, dy, dwidth, dheight, path);
            ////氏名の画像を作成
            ////住所の画像を作成
            ////電話番号の画像を作成
        }
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(this.TxtStartNo.Text))
            {
                return false;
            }
            if (string.IsNullOrEmpty(this.TxtReadTextNo.Text))
            {
                return false;
            }
            return true;
        }
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // TODO
            // 入力チェック
            if (!CheckInput()) { return; }

            this.Start = int.Parse(this.TxtStartNo.Text);
            this.End = int.Parse(this.TxtReadTextNo.Text);
            // TODO
            // 読み込む画像があるフォルダーに画像があった場合すべて削除する。

            // PDFからPNGへ変換 -> 無料版では4件までしかできない
            //var pdf = new PdfDocumenter(pdfFilePath, saveDirectoryPath);
            //// 画像をリサイズして保存
            //pdf.ConvertToPng(this.Start, this.End);

            //開始ぺージから終了ページまでをループする
            var start = this.Start;
            var end = this.End;

            for(int page = start; page < end; page++)
            {
                //開始ページから画像を読み込む
                var trgtImgPath = string.Format("\\" + targetOriginImgPathFmt, page.ToString().PadLeft(3, '0'));
                var targetImagePath = $"{originImagePath}{trgtImgPath}";


                // 左の表を保存する
                var leftOutputPath = $"{outputFilePath}p{page}_L.png";
                var leftImg = new Image(targetImagePath, leftOutputPath);
                leftImg.Split2Part(this.SrcLeftRectangle.X, this.SrcLeftRectangle.Y,
                    this.SrcLeftRectangle.W, this.SrcLeftRectangle.H, 
                    this.DstLeftRectangle.X, this.DstLeftRectangle.Y,
                    this.DstLeftRectangle.W, this.DstLeftRectangle.H);
                // 右の表を保存する
                var rightOutputPath = $"{outputFilePath}p{page}_R.png";
                var rightImg = new Image(targetImagePath, rightOutputPath);
                rightImg.Split2Part(this.SrcRightRectangle.X, this.SrcRightRectangle.Y,
                    this.SrcRightRectangle.W, this.SrcRightRectangle.H,
                    this.DstRightRectangle.X, this.DstRightRectangle.Y,
                    this.DstRightRectangle.W, this.DstRightRectangle.H);
            }

            // TODO
            // 画像からテキスト読み込み
            SetReadText();

            // TODO [TRIAL] ->
            OutputReadedText();
            // <- TODO [TRIAL]

            // TODO
            // エクセルに出力
            // エクセルを表示
            this.label3.Text = "完了しました。";
        }
        private void ChangeEnabledSubmitBtn()
        {
            var validSubmitBtn = false;
            if (!string.IsNullOrEmpty(this.TxtStartNo.Text) && !string.IsNullOrEmpty(this.TxtReadTextNo.Text))
            {
                validSubmitBtn = true;
            }

            this.BtnSubmit.Enabled = validSubmitBtn;
        }
        private void TxtStartNo_TextChanged(object sender, EventArgs e)
        {
            ChangeEnabledSubmitBtn();
        }

        private void TxtReadTextNo_TextChanged(object sender, EventArgs e)
        {
            ChangeEnabledSubmitBtn();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    internal class CurrentReadTextImage
    {
        internal int CurrentPage { get; private set; }
        internal ERightOrLeft RightOrLeft { get; private set; }
        internal EReadColumn ReadColumn { get; private set; }
        internal string ImagePath { get ; private set; }

        internal enum ERightOrLeft
        {
            R,
            L
        }
        internal enum EReadColumn
        {
            Name,
            Address,
            Tel
        }
        public CurrentReadTextImage(int page, ERightOrLeft rightOrLeft, EReadColumn readColumn, string path) : 
            this(page, readColumn, path)
        {
            this.RightOrLeft = rightOrLeft;
        }
        public CurrentReadTextImage(int page, EReadColumn readColumn, string path)
        {
            this.CurrentPage = page;
            this.ReadColumn = readColumn;
            this.ImagePath = path;
        }
        internal string GetPageAndColumn()
        {
            return $"p{this.CurrentPage}_{this.ReadColumn}";
        }
        internal int GetFileCount(string imagePath, string pattern)
        {
            return Directory.GetFiles(imagePath, pattern).Length;
        }
    }
    internal class CurrentReadTextImageCollectionItem : Dictionary<CurrentReadTextImage.EReadColumn, string>
    {
        private CurrentReadTextImage currentReadTextImage { get; set; }
        internal string ImagePath { get; set; }

        public CurrentReadTextImageCollectionItem(CurrentReadTextImage crt)
        {
            this.currentReadTextImage = crt;
            this.ImagePath = crt.ImagePath;
        }
        internal CurrentReadTextImageCollectionItem GetTextDicImage(CurrentReadTextImage crt, int colCount)
        {
            var textDictionary = new CurrentReadTextImageCollectionItem(crt);

            for (int iCol = 1; iCol < colCount + 1; iCol++)
            {
                // 形式：p5_R_tel1.png
                var imgPath = $"{ImagePath}p{crt.CurrentPage}_{crt.RightOrLeft}_{crt.ReadColumn}{iCol}.png";

                // ファイルの存在確認
                if (File.Exists(imgPath))
                {
                    var txt = GetTextImage(imgPath);
                    textDictionary.Add(crt.ReadColumn + iCol, txt);
                }
            }
            return textDictionary;
        }
        internal string GetTextImage(string path)
        {
            var reader = new TextDocumentReader(path);
            var txt = reader.GetImageDuringCharacter();
            return txt;
        }
    }
    internal class CurrentReadTextImageCollection : Dictionary<string, CurrentReadTextImageCollectionItem>
    {
        private CurrentReadTextImage currentReadTextImage { get; set; }
        public CurrentReadTextImageCollection(CurrentReadTextImage crt) 
        {
            this.currentReadTextImage = crt;
        }
        internal Dictionary<CurrentReadTextImage.EReadColumn, string> GetCollection(string imagePath, string pattern)
        {
            var crt = this.currentReadTextImage;
            var crtL = new CurrentReadTextImage(crt.CurrentPage, CurrentReadTextImage.ERightOrLeft.L, crt.ReadColumn, imagePath);
            var crtR = new CurrentReadTextImage(crt.CurrentPage, CurrentReadTextImage.ERightOrLeft.R, crt.ReadColumn, imagePath);
            var count = crt.GetFileCount(imagePath, pattern);
            var item = new CurrentReadTextImageCollectionItem(crt);
            var textDictionaryL = item.GetTextDicImage(crtL, count);
            var textDictionaryR = item.GetTextDicImage(crtR, count);
            var textDictionary = textDictionaryL.Concat(textDictionaryR).ToDictionary(c => c.Key, c => c.Value);
            return textDictionary;
        }
    }

    internal class RectangeInfos
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int W { get; set; }
        internal int H { get; set; }

        internal enum RectangleKey
        {
            X, Y, W, H
        }

        public RectangeInfos() 
        {
            this.X = 0; 
            this.Y = 0;
            this.W = 0;
            this.H = 0;
        }

        public RectangeInfos(int x, int y, int w, int h) 
        { 
            this.X = x;
            this.Y = y;
            this.W = w;
            this.H = h;
        }
    }
}
