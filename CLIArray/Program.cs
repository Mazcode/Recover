using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CLIArray.LearnArray;

namespace CLIArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LearnArray.FirstArr();
            //LearnArray.Traverse();
            //int[] score = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            //Demo.CalAvgScore(score);

            //MulDimension.MDArray();
            //MulDimension.JaggedArray();
            //UseArrayClass demo = new UseArrayClass();
            //Exercises.Question4();

            //Console.WriteLine($"{string.Join(",", Exercises.Question4_1(new int[] { 1, 3, 5, 3, 7, 1, 9, 5, 11 }))}");

            //Console.WriteLine($"{string.Join(",", Exercises.Question4_1(new int[] { 1, 1, 1, 1 }))}");
            //// 输出: 1

            //Console.WriteLine($"{string.Join(",", Exercises.Question4_1((new int[] { 1, 2, 3, 4 })))}");
            //// 输出: 1,2,3,4

            //Console.WriteLine($"{string.Join(",", Exercises.Question4_1(new int[] { }))}");
            //// 输出: (空)

            //Console.WriteLine($"{string.Join(",", Exercises.Question4_1((new int[] { 5 })))}");
            //// 输出: 5
            //Console.ReadKey();
            LotterySimulator simulator = new LotterySimulator();
            simulator.Run();


        }
    }
}
