using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            UrlExporter exporter = new UrlExporter();
            exporter.Export(System.IO.Directory.GetCurrentDirectory() + "\\TestDoc.txt");
            Console.ReadLine();
        }
    }
}
