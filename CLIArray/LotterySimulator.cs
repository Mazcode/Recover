using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CLIArray
{
    /// <summary>
    /// 彩票开奖模拟器
    /// </summary>
    internal class LotterySimulator
    {
        bool keepPlaying = true;
       

        public void Run()
        {
            ShowWelcome();
            while (keepPlaying)//用户不退出就一直循环
            {
                //var userInput = GetUserInput();
                var userInput = new[] { 3, 10, 12, 20, 25, 30, 8 };
                var lotteryNumbers = GenerateLotteryNumbers();
                Console.WriteLine($"用户已输入7个号码{string.Join(",",userInput)}");

                //开始比较
                var matchCount = CompareNumbers(lotteryNumbers, userInput);
                Console.WriteLine($"有{matchCount}个相同");

                //显示结果
                ShowResult(lotteryNumbers, userInput, matchCount);
                keepPlaying = AskUserContinue();
            }

        }
        /// <summary>
        /// 获取用户输入7个号码
        /// </summary>
        private static int[] GetUserInput()
        {
            Console.WriteLine("请输入范围1-35内7个不重复的正整数号码，每输入一个按回车");
            int rounds = 7;//输入号码个数
            int count = 0;//输入计数
            int[] userInput = new int[rounds];
            while (count < rounds)
            {
                bool isRepeat = false;
                Console.Write($"第 {count + 1} 个号码：");
                var input= Console.ReadLine();
                //这里有可能是直接退出不输入，先留着，再想想怎么处理
                if (input == null)
                {
                    Console.WriteLine("输入为空，请重新输入！");
                    continue;
                }
                if (int.TryParse(input, out int current))
                { 
                    if (current<1||current>35)
                    {
                        Console.WriteLine("输入数字必须为1-35范围内正整数");
                        continue;
                    }
                    //检查是否重复，之前没有输入过的才可以继续输入
                    for (int i = 0; i < count; i++)
                    {
                        if (userInput[i]==current)
                        {
                            isRepeat = true;
                            break;
                        }
                    }
                    if (isRepeat)
                    {
                        Console.WriteLine("号码不能重复！请重新输入。\n");
                        continue;
                    }
                    userInput[count] = current;
                    count++;
                    Console.WriteLine($"已输入：{current}");
                }
                else
                {
                    Console.WriteLine("无效输入");
                    continue;
                }
                

            }
            return userInput;
        }

        private static Random random = new Random();
        /// <summary>
        /// 生成彩票号码
        /// </summary>
        private static int[] GenerateLotteryNumbers()
        {
            int rounds = 7;//输入号码个数
            int count = 0;//输入计数
            int[] lotteryNumbers = new int[rounds];
           
            while (count < rounds)
            {
                bool isRepeat = false;
                //检查是否重复，之前没有生成的才可以加入数组
                var current = random.Next(1,36);
                for (int i = 0; i < count; i++)
                {
                    if (lotteryNumbers[i] == current)
                    {
                        isRepeat = true;
                        break;
                    }
                }
                if (isRepeat)
                {
                    Console.WriteLine("号码不能重复！请重新输入。\n");
                    continue;
                }
                lotteryNumbers[count] = current;
                count++;
            }

            return lotteryNumbers;
        }

        /// <summary>
        /// 对比两个数组，返回猜中的数量
        /// </summary>
        /// <param name="lottery"></param>
        /// <param name="userinput"></param>
        /// <returns></returns>
        private static int CompareNumbers(int[] lottery, int[] userinput)
        {
            int count= 0;//计数相同的数字
            for (int i = 0; i < lottery.Length; i++)
            {
                for (int j = 0; j < userinput.Length; j++)
                {
                    if (lottery[i] == userinput[j])
                    {
                        count++;
                    }
                }
            }
           
            return count;   
        }

        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="lottery"></param>
        /// <param name="userinput"></param>
        /// <param name="matchCount"></param>
        static void ShowResult(int[] lottery, int[] userinput, int matchCount)
        {
            if (userinput == null) return;  // 用户取消输入

            Array.Sort(lottery);
            Array.Sort(userinput);

            Console.WriteLine();
            Console.WriteLine("开奖结果");
            Console.WriteLine();

            Console.Write("开奖号码: ");
            foreach (int num in lottery)
            {
                Console.Write($"{num,2} ");
            }
            Console.WriteLine();

            Console.Write("你的号码: ");
            foreach (int num in userinput)
            {
                Console.Write($"{num,2} ");
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("────────────────────────────────────────────────");
            Console.WriteLine($" 猜中 {matchCount} 个！");
            Console.WriteLine("────────────────────────────────────────────────");

            string prize = GetPrize(matchCount);
            Console.WriteLine();
            Console.WriteLine($"🏆 {prize}");
            Console.WriteLine();
        }

        static string GetPrize(int matchCount)
        {
            switch (matchCount)
            {
                case 7: return " 猜中7个！恭喜获得一等奖！";
                case 6: return " 猜中6个！恭喜获得二等奖！";
                case 5: return " 猜中5个！恭喜获得三等奖！";
                case 4: return " 猜中4个！恭喜获得四等奖！";
                case 3: return " 猜中3个！恭喜获得五等奖！";
                default: return "很遗憾，未中奖。再接再厉！";
            }
        }

        private static void ShowWelcome()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════╗");
            Console.WriteLine();
            Console.WriteLine("           彩票开奖模拟器                   ");
            Console.WriteLine("                                                    ");
            Console.WriteLine("        规则：从1-35中选择7个不重复的号码           ");
            Console.WriteLine("        猜中3个及以上即可中奖！                     ");
            Console.WriteLine();
            Console.WriteLine("╚════════════════════════════════════════════════════╝");
        }


        /// <summary>
        /// 询问用户是否继续
        /// </summary>
        /// <returns>继续返回true，否则返回false</returns>
        private static bool AskUserContinue()
        {
            Console.WriteLine("是否继续游戏？Y/N");
            while(true)
            {
                string input = Console.ReadLine()?.Trim().ToLower();

                if (input == "y" )
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.Write("无效输入，请输入 Y 或 N: ");
                }
            }
        }

    }
}
