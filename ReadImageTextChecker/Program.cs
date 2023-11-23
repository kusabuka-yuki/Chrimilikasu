using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Chrimilikasu;

namespace ReadImageTextChecker
{
    internal class Program
    {
        private const string srcPath = @"C:\test\test_ractangle.png";

        static void Main(string[] args)
        {
            var txtReader = new TextDocumentReader(srcPath);
            var result = txtReader.GetImageDuringCharacter();

            var outputter = new ReadedTextOutputer();
            outputter.OutputReadedText(result);
        }
    }

    internal class ReadedTextOutputer
    {
        private const string destPath = @"C:\test\result_txt.txt";

        internal void OutputReadedText(string result)
        {
            var outputPath = destPath;
            using (var writer = new StreamWriter(outputPath, false))
            {
                writer.WriteLine(result);
            }
        }
    }
}
