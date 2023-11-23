using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chrimilikasu
{
    public class Image
    {
        public string SourceFilePath { get; private set; }
        public string DestFilePath { get; private set; }
        private const string destFileNameSplit2PartRight = "p5_R.png";
        private const string destFileNameSplit2PartLeft = "p5_L.png";

        private Bitmap SelfImage
        {
            get;set;
        }

        public Image(string sourceFilePath, string destFilePath) 
        {
            // TODO
            //sourceFilePath = @"G:\マイドライブ\ドライブ\クラウドワークス\chrimilikatsu\193.A12158E 山武農業(1999)\193.A12158E 山武農業(1999)-005.png";
            SourceFilePath = sourceFilePath;
            DestFilePath = destFilePath;
            Console.WriteLine($"SourceFilePath: {SourceFilePath}");
            SelfImage= new Bitmap(SourceFilePath);
        }
        public void Save(Bitmap img, string outputPath)
        {
            img.Save(outputPath, System.Drawing.Imaging.ImageFormat.Png);
        }
        //public void Split2PartRight(int srcX, int srcY, int srcW, int srcH, int destX, int destY, int destW, int destH)
        //{
        //    var path = $"{outputFilePath}{destFileNameSplit2PartRight}";
        //    Split2Part(srcX, srcY, srcW, srcH, destX, destY, destW, destH, path);
        //}
        //public void Split2PartLeft(int srcX, int srcY, int srcW, int srcH, int destX, int destY, int destW, int destH) 
        //{
        //    var path = $"{outputFilePath}{destFileNameSplit2PartLeft}";
        //    Split2Part(srcX, srcY, srcW, srcH, destX, destY, destW, destH, path);
        //}
        public void Split2Part(int srcX, int srcY, int srcW, int srcH,int destX, int destY, int destW, int destH)
        {
            var destFilePath = this.DestFilePath;
            // 画像を切り抜く範囲を指定
            Rectangle srcRect = new Rectangle(srcX, srcY, srcW, srcH);

            // 切り抜かれた画像のサイズを指定
            Rectangle destRect = new Rectangle(destX, destY, destW, destH);

            Bitmap destImage = new Bitmap(destRect.Width, destRect.Height);
            Graphics graphics = Graphics.FromImage(destImage);
            graphics.DrawImage(SelfImage, destRect, srcRect, GraphicsUnit.Pixel);
            graphics.Dispose();

            Save(destImage, destFilePath);

            // 画像リソースを解放
            SelfImage.Dispose();
            destImage.Dispose();
        }
    }
}
