using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineDemo
{
    internal class CompletedState : OrderStateBase
    {
        public override void HandlePay() => Reject("订单已完成，无操作");
        public override void HandleShip() => Reject("订单已完成，无操作");
        public override void HandleConfirm() => Reject("订单已完成，无操作");
        public override void HandleCancel() => Reject("订单已完成，无操作");

        public override void OnEnter() => Console.WriteLine("进入状态：[已完成]");
    
    }
}
