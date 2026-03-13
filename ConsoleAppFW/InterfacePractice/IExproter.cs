using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFW.InterfacePractice
{
    //重构代码
    //public class ReportGenerator
    //{
    //    public void Generate()
    //    {
    //        PdfExporter exporter = new PdfExporter(); // 硬编码依赖
    //        exporter.Export("Report Content");
    //    }
    //}
    //public class PdfExporter
    //{
    //    public void Export(string content) { Console.WriteLine("Exporting PDF: " + content); }
    //}
    internal interface IExproter
    {
        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="content">需要导出内容</param>
        void Export(string content);
    }

    class PdfExporter:IExproter
    {
        public void Export(string content) { Console.WriteLine("Exporting PDF: " + content); }
    }

    class ExcelExporter : IExproter
    {
        public void Export(string content) { Console.WriteLine("Exporting Excel: " + content); }
    }

    class ReportGenerator
    {
        private IExproter _exporter;
        public IExproter Exporter { get => _exporter; set => _exporter = value; }
        public ReportGenerator(IExproter exproter) 
        {
            Exporter = exproter;
        }

        public void Generate(string content)
        {
            _exporter.Export(content);
        }
    }
}
