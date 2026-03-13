using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    internal class DivCommand : ICommand
    {
        public string Name => "除法";
        public string Description => "DIV <数字> : 将当前值除以数字";
        public void Execute(ref decimal current, string[] args)
        {
            if (args.Length != 1) throw new ArgumentException("需要提供一个数字参数");
            decimal number = decimal.Parse(args[0]);
            if (number == 0) throw new DivideByZeroException("除数不能为零！");
            current /= number;
            Console.WriteLine($">>> 执行除法：/{number}，当前结果：{current}");
        }
    }
}
