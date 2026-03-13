using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    internal class SubCommand:ICommand
    {
        public string Name => "减法";
        public string Description => "SUB <数字> : 将数字被当前值减去";

        public void Execute(ref decimal current, string[] args)
        {
            if (ArgHelpers.TryGetDecimal(args, out decimal number, out string errmsg))
            {
                current -= number;
                Console.WriteLine($">>> 执行减法：-{number}，当前结果：{current}");
            }
            else
            {
                throw new ArgumentException(errmsg);
            }
        }
    }
}
