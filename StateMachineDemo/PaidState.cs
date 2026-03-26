namespace StateMachineDemo
{
    internal class PaidState : OrderStateBase
    {
        public override void HandleCancel()
        {
            Console.WriteLine("正在处理退款...");
            // 实现：跳转到取消状态
            context.StateTransition(new CancelledState());
        }

        public override void HandleConfirm() => Reject("");


        public override void HandlePay() => Reject("警告：重复支付");


        public override void HandleShip()
        {
            Console.WriteLine("安排发货...");
            context.StateTransition(new ShippedState());
        }
    }
}