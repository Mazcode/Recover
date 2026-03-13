using CLIDemo.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            #region 老代码
            //Console.WriteLine("========================================");
            //Console.WriteLine("欢迎使用简易命令处理器！");
            //Console.WriteLine("指令格式: ADD <数字>  (例如: ADD 100)");
            //Console.WriteLine("输入 'quit' 或 'exit' 退出程序。");
            //Console.WriteLine("========================================\n");

            //bool isRunning = true;//一个信号控制程序是否退出
            //decimal current = 0m;
            //while (isRunning)
            //{
            //    Console.Write("请输入指令：");
            //    string input = Console.ReadLine();
            //    if (string.IsNullOrWhiteSpace(input))
            //    {
            //        Console.WriteLine("[提示] 输入不能为空，请重新输入。\n");
            //        continue;//跳过本次，进入下一个循环
            //    }

            //    //分解输入，获取指令和输入的数字
            //    //考虑只输入多个空格造成分割出空字符串
            //    var parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    if (parts.Length == 0)
            //    {
            //        Console.WriteLine("[提示] 输入无效。\n");
            //        continue;
            //    }


            //    var command = parts[0].ToLower();
            //    // 优先处理退出指令，不用带参数
            //    if (command == "quit" || command == "exit")
            //    {
            //        Console.WriteLine("\n正在退出程序... 再见！");
            //        isRunning = false; // 改变标志位，结束 while 循环
            //        continue;
            //    }
            //    //检查参数数量：除了退出指令外，其他指令(如ADD)需要2个部分
            //    if (parts.Length != 2)
            //    {
            //        Console.WriteLine("[错误] 指令格式不正确！");
            //        Console.WriteLine("正确格式应为: ADD <数字>\n");
            //        continue;
            //    }
            //    var numStr = parts[1];
            //    decimal number;
            //    if (!decimal.TryParse(numStr, out number))
            //    {
            //        Console.WriteLine($"[错误] '{numStr}' 不是一个有效的数字！");
            //        Console.WriteLine("请确保第二个参数是数字格式。\n");
            //        continue;
            //    }
            //    switch (command)
            //    {

            //        case "add":
            //            current += number;
            //            Console.WriteLine($"[成功] 已执行加法：+ {number}");
            //            Console.WriteLine($"       当前累计结果：{current}\n");
            //            break;
            //        default:
            //            Console.WriteLine($"[错误] 未知指令 '{parts[0]}'。");
            //            Console.WriteLine("       目前仅支持指令: ADD <数字>");
            //            Console.WriteLine("       退出指令: quit, exit\n");
            //            break;
            //    }
            //}
            //Console.WriteLine("江湖再见！！拜拜");
            //Console.ReadKey();
            #endregion

            #region 船新版本
            Console.Write("> ");
            decimal current = 0m;
            bool isRunning = true;//运行标识
            Dictionary<string, Command.ICommand> commandDic = InitializeCommands();//初始化指令表
            ExcuteCmd(commandDic["help"],ref current,Array.Empty<string>());
            while (isRunning)
            {
                string input = Console.ReadLine();
                //如果用户没有输入，直接Ctrl+Z退出
                if (input == null)
                {
                    Console.WriteLine("\n检测到退出信号。");
                    isRunning = false;
                    continue;
                }
                string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 0)
                {
                    Console.WriteLine("别以为我不知道你没输入啊");
                    continue;
                }
                var cmdName = parts[0];
                //获取数字
                string[] commandArgs = parts.Skip(1).ToArray();

                if (cmdName.ToLower() == "quit")//这里硬编码算了不搞花里胡哨
                {
                    Console.WriteLine("江湖再见！！拜拜");
                    isRunning = false;
                    continue;
                }
                
                //查找指令表，执行
                if (commandDic.TryGetValue(cmdName, out Command.ICommand command))
                {
                    ExcuteCmd(command, ref current, commandArgs);
                }
                else
                {
                    PrintError($"无效指令:{cmdName}，请输入HELP查看指令");
                    continue;
                }
            }
            Console.WriteLine("江湖再见！！拜拜");
            Console.ReadKey();
            #endregion
        }

        /// <summary>
        /// 指令表初始化
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, Command.ICommand> InitializeCommands()
        {
            // 1. 先创建所有具体的指令实例
            var addCmd = new AddCommand();
            var subCmd = new SubCommand();
            var mulCmd = new MulCommand();
            var divCmd = new DivCommand();
            var resetCmd = new ResetCommand();

            // 2. 把它们放入一个临时的列表中（为了传给 HelpCommand）
            var commandList = new List<Command.ICommand>
            {
                addCmd, subCmd, mulCmd, divCmd, resetCmd
            };

            // 3. 创建 HelpCommand，把上面的列表传进去
            var helpCmd = new HelpCommand(commandList);

            //注册命令
            return new Dictionary<string, Command.ICommand>(StringComparer.OrdinalIgnoreCase)
            {
                { "add", addCmd },
                { "sub", subCmd },
                { "mul", mulCmd },
                { "div", divCmd },
                { "reset", resetCmd },
                { "help", helpCmd }
            };
        }

        /// <summary>
        /// 指令执行包含异常处理
        /// </summary>
        /// <param name="command"></param>
        /// <param name=""></param>
        /// <param name="args"></param>
        private static void ExcuteCmd(Command.ICommand command, ref decimal current, string[] args)
        {
            try
            {
                command.Execute(ref current, args);
            }
            catch (ArgumentException ex)
            {
                PrintError(ex.Message);
                Console.WriteLine($"提示：{command.Description}");
            }
            catch (DivideByZeroException ex)//除以0的特定错误
            {
                PrintError(ex.Message);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
        }

        /// <summary>
        /// 统一打印报错信息，修改信息字体颜色显示
        /// </summary>
        /// <param name="excetionMessage">报错信息</param>
        private static void PrintError(string excetionMessage)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[报错信息]：{excetionMessage}");
            Console.ResetColor();
        }
    }
}
