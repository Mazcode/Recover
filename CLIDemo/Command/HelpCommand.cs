using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLIDemo.Command
{
    internal class HelpCommand:ICommand
    {
        private readonly IEnumerable<ICommand> _commandList;
        public HelpCommand(IEnumerable<ICommand> commandList)
        {
            _commandList = commandList;
        }
        public string Name => "HELP";
        public string Description => "显示所有可用指令";

        public void Execute(ref decimal current, string[] args)
        {
            Console.WriteLine("\n========== 可用指令列表 ==========");

            // 3. 遍历传入的列表进行打印
            // 注意：我们通常跳过 HELP 命令本身，或者按字母排序
            foreach (var cmd in _commandList.OrderBy(c => c.Name))
            {
                // 格式化输出：命令名左对齐占10位
                Console.WriteLine($"  {cmd.Name,-10} : {cmd.Description}");
            }

            Console.WriteLine("==================================\n");
        }
    }
}
