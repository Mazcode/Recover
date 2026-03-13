using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    // --- 乘法命令 ---
    internal class MulCommand : ICommand
    {
        public string Name => "乘法";
        public string Description => "MUL <数字> : 将当前值乘以数字";
        public void Execute(ref decimal current, string[] args)
        {
            if (ArgHelpers.TryGetDecimal(args, out decimal number, out string errmsg))
            {
                current *= number;
                Console.WriteLine($">>> 执行乘法：*{number}，当前结果：{current}");
            }
            else
            {
                throw new ArgumentException(errmsg);
            }
        }
    }
}
