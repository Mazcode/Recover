using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ = args;
            //LearnThread.ThreadRun();
            //LearnThread.Exercise1();

            //传递参数给线程
            //ThreadWithPrams.Run();

            //线程返回结果
            ThreadReturnValue.Run();
        }
    }
}
