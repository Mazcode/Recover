using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CLIThread
{
    internal class LearnThread
    {
        #region
        public static void ThreadRun()
        {
            //获取主线程
            Thread thread = Thread.CurrentThread;
            thread.Name = "主线程";
            Console.WriteLine($"主线程名称:{thread.Name}");
            Console.WriteLine($"主线程ID：{thread.ManagedThreadId}");
            Console.WriteLine($"主线程状态：{thread.ThreadState}");

            Thread workerThread = new Thread(DoWork)
            {
                Name="工作线程-1"
            };

            //启动前
            Console.WriteLine($"子线程状态(启动前)：{workerThread.ThreadState}");

            workerThread.Start();

            Console.WriteLine($"子线程状态(启动后)：{workerThread.ThreadState}");

            Console.WriteLine($"主线程继续工作");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"主线程工作：第{i+1}次");
                Thread.Sleep(300);
                Console.WriteLine($"Thread Name:{Thread.CurrentThread.Name}");
                Console.WriteLine($"Thread ID:{Thread.CurrentThread.ManagedThreadId}");
                Console.WriteLine($"thread Name:{thread.Name}");
                Console.WriteLine($"thread ID:{thread.ManagedThreadId}");
                Console.WriteLine($"线程状态:{thread.ThreadState}");
            }

            workerThread.Join();//等待子线程结束;
            Console.WriteLine($"子线程状态（结束后）：{workerThread.ThreadState}");
            Console.WriteLine($"结束");
            Console.WriteLine($"主线程状态：{thread.ThreadState}");
        }

        private static void DoWork()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"\n[{currentThread.Name}] 开始工作，ID: {currentThread.ManagedThreadId}");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"[{currentThread.Name}] 处理任务: {i}");
                Thread.Sleep(400); // 模拟耗时操作
            }

         
            Console.WriteLine($"[{currentThread.Name}] 工作完成");
        }
        #endregion

        #region 练习1
        //创建3个子线程，分别打印1-10的数字
        //设置一个后台线程，验证主线程结束时后台线程的行为
        //主线程代码执行完后，程序没有退出，而是等待前台线程完成。
        public static void Exercise1()
        {
            Thread t1 = new Thread(PrintNumber)
            {
                Name = "线程A"
            };
            Thread t2 = new Thread(PrintNumber)
            {
                Name = "线程B"
            };
            Thread t3 = new Thread(PrintNumber)
            {
                Name = "线程C"
            };
            //这里属于前台模型

            t1.Start();
            t2.Start();
            t3.Start();

            Thread backgroundThread = new Thread(() =>
            {
                int count = 0;
                while (true)
                {
                    Console.WriteLine($"张祺第{count += 1}跟你Say Hi。");

                    if (count == 99)
                    {
                        Thread.CurrentThread.Abort();
                    }
                }
            })
            {
                Name = "后台线程",
                IsBackground = true
            };
            backgroundThread.Start();

            t1.Join();//等待t1完成
            t2.Join();//等待t2完成
            t3.Join();//等待t3完成
            backgroundThread.Join();
            Console.WriteLine("结束了");
            
        }

        private static void PrintNumber()
        {
           
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"当前线程名:{Thread.CurrentThread.Name},输出{i+1}");
                //Thread.Sleep(2000);
            }
        }
        #endregion
    }
}
