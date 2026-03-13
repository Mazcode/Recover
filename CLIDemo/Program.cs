using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo
{
    /// <summary>
    /// 一个控制台练习
    /// 写一个控制台代码，可以一直接收用户输入，并在用户输入有问题的时候提醒，并可以继续输入，最后以某种形式的输入退出
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("欢迎使用简易命令处理器！");
            Console.WriteLine("指令格式: ADD <数字>  (例如: ADD 100)");
            Console.WriteLine("输入 'quit' 或 'exit' 退出程序。");
            Console.WriteLine("========================================\n");

            bool isRunning = true;//一个信号控制程序是否退出
            decimal current = 0m;
            while (isRunning)
            {
                Console.Write("请输入指令：");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("[提示] 输入不能为空，请重新输入。\n");
                    continue;//跳过本次，进入下一个循环
                }

                //分解输入，获取指令和输入的数字
                //考虑只输入多个空格造成分割出空字符串
                var parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0)
                {
                    Console.WriteLine("[提示] 输入无效。\n");
                    continue;
                }


                var command = parts[0].ToLower();
                // 优先处理退出指令，不用带参数
                if (command == "quit" || command == "exit")
                {
                    Console.WriteLine("\n正在退出程序... 再见！");
                    isRunning = false; // 改变标志位，结束 while 循环
                    continue;
                }
                //检查参数数量：除了退出指令外，其他指令(如ADD)需要2个部分
                if (parts.Length != 2)
                {
                    Console.WriteLine("[错误] 指令格式不正确！");
                    Console.WriteLine("正确格式应为: ADD <数字>\n");
                    continue;
                }
                var numStr = parts[1];
                decimal number;
                if (!decimal.TryParse(numStr, out number))
                {
                    Console.WriteLine($"[错误] '{numStr}' 不是一个有效的数字！");
                    Console.WriteLine("请确保第二个参数是数字格式。\n");
                    continue;
                }
                switch (command)
                {
                  
                    case "add":
                        current += number;
                        Console.WriteLine($"[成功] 已执行加法：+ {number}");
                        Console.WriteLine($"       当前累计结果：{current}\n");
                        break;
                    default:
                        Console.WriteLine($"[错误] 未知指令 '{parts[0]}'。");
                        Console.WriteLine("       目前仅支持指令: ADD <数字>");
                        Console.WriteLine("       退出指令: quit, exit\n");
                        break;
                }
            }
            Console.WriteLine("江湖再见！！拜拜");
            Console.ReadKey();
        }
    }
}
