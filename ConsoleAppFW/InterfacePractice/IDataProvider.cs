using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFW.InterfacePractice
{
    internal interface IDataProvider
    {
        string GetData();
    }

    class ApiDataProvider:IDataProvider
    {
        public string GetData()
        {
            return "Data from API.";
        }
    }

    class FileDataProvider : IDataProvider
    {
        public string GetData()
        {
            return "Data from File.";
        }
    }

    //调用不同接口实现的类
    class BusinessService
    {
        public BusinessService(IDataProvider dataProvider)
        {
            if (dataProvider==null)
            {
                throw new ArgumentNullException($"{nameof(dataProvider)} 不能为空。");
            }
            Console.WriteLine(dataProvider.GetData());
        }
    }
}
