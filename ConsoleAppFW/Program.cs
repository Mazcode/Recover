using ConsoleAppFW.InterfacePractice;
using System;// 引用的库
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFW//命名空间
{
    /// <summary>
    /// 类名
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args">字符串数组</param>
        static void Main(string[] args)
        {
            ////Console.WriteLine("Hello Max");
            //Practice.Practice9();
            #region 练习1

            //List<IShape> shapes = new List<IShape>() {
            //    new Circle(10),
            //    new Rectangle(20,30)
            //};

            //foreach (IShape shape in shapes)
            //{
            //    Console.WriteLine($" 面积为{shape.GetArea() }");
            //}
            #endregion

            #region 练习2
            //Duck duck = new Duck("大B");
            //duck.Fly();
            //duck.Swim();
            ////显示实现的接口方法必须转换成对应的接口才能调用对应的方法
            //((IFlyable)duck).DoWork();
            //((ISwimmable)duck).DoWork();
            #endregion

            #region 练习3

            //BusinessService businessService1 = new BusinessService(new ApiDataProvider());
            //BusinessService businessService2 = new BusinessService(new FileDataProvider());
            #endregion

            #region 练习4
            var gen1 = new ReportGenerator(new PdfExporter());
            gen1.Generate("YOYO");
            gen1.Exporter = new ExcelExporter();
            gen1.Generate("Exo");
            #endregion

            Console.ReadLine();
        }
    }
}
