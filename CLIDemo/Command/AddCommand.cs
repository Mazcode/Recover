using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    internal class AddCommand:ICommand
    {
        public string Description=> "ADD <数字> : 将数字加到当前值";

        public string Name => "加法";

        public void Execute(ref decimal current, string[] args)
        {
            if (ArgHelpers.TryGetDecimal(args, out decimal number, out string errmsg))
            {
                current += number;
                Console.WriteLine($">>> 执行加法：+{number}，当前结果：{current}");
            }
            else
            {
                throw new ArgumentException(errmsg);
            }
        }


    }
}
