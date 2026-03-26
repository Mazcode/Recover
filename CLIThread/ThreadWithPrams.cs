using System;
using System.Threading;

namespace CLIThread
{
    /// <summary>
    /// 线程传递参数
    /// </summary>
    internal class ThreadWithPrams
    {
        public static void Run()
        {
            Console.WriteLine("===线程参数传递====");

            Thread t1 = new Thread(WorkWithParam);
            t1.Start("Start里面传参数");//可以通过start重载的方法放入参数

            //本身Thread的参数是一个委托，可以用这种方式，传多个参数都行
            Thread t2= new Thread(() => {
                WorkWithParam2("lambda表达式");
            });
            t2.Start();
            Thread t3 = new Thread(() => {
                WorkWithParam3("多个参数",12);
            });
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

        }

        static void WorkWithParam(object obj)
        {
            Console.WriteLine($"第1种方式接受参数:{obj}");
        }
        static void WorkWithParam2(string msg)
        {
            Console.WriteLine($"第2种方式接受参数：{msg}");
        }

        static void WorkWithParam3(string msg,int counter)
        {
            Console.WriteLine($"第三种，同时传入多个参数");
            Console.WriteLine($"传入：{msg},计数：{counter}");
        }

    }
}
