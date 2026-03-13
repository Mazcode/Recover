using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    internal class ResetCommand : ICommand
    {
        public string Name => "重置";
        public string Description => "RESET : 将当前值重置为 0";
        public void Execute(ref decimal current, string[] args)
        {
            current = 0m;
            Console.WriteLine(">>> 已重置，当前结果：0");
        }
    }
}
