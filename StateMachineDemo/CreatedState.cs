using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineDemo
{
    internal class CreatedState:OrderStateBase
    {
        public override void HandleCancel()
        {
            System.Console.WriteLine("订单取消");
            context.StateTransition(new CancelledState());
        }
        public override void HandlePay()
        {
            Console.WriteLine("💰 处理支付...");
            context.StateTransition(new PaidState());
        }

        public override void HandleConfirm() => Reject("");

        public override void HandleShip() => Reject("");
        public override void OnEnter() => Console.WriteLine("进入状态：[已创建]");
    }
}
