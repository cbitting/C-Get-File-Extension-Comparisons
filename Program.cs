using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace fileExtensionGetTests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Reset();
            sw.Start();

            for (int i = 1; i <= 900000; i++)
            {
                string ext = Path.GetExtension("http://www.chrisbitting.com/folder/another/file.pdf");
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());

            sw.Reset();
            sw.Start();
            for (int i = 1; i <= 900000; i++)
            {
                if ("http://www.chrisbitting.com/folder/another/file.pdf".EndsWith(".pdf"))
                {
                    string ext = ".pdf";
                }
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());

            sw.Reset();
            sw.Start();
            for (int i = 1; i <= 900000; i++)
            {
                string ext = Regex.Match("http://www.chrisbitting.com/folder/another/file.pdf", "(\\.[^.]+)$").Value;
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());

            sw.Reset();
            sw.Start();
            for (int i = 1; i <= 900000; i++)
            {
                string[] extp = "http://www.chrisbitting.com/folder/another/file.pdf".Split(new string[] { "\\." }, StringSplitOptions.RemoveEmptyEntries);
                string ext = extp[extp.Length - 1];
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds.ToString());

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
