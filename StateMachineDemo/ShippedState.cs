namespace StateMachineDemo
{
    internal class ShippedState : OrderStateBase
    {
        public override void HandlePay() => Reject("错误：当前状态不能执行此操作");
        public override void HandleShip() => Reject("错误：当前状态不能执行此操作");
        public override void HandleConfirm()
        {
            Console.WriteLine("确认收货...");
            context.StateTransition(new CompletedState());
        }
        public override void HandleCancel() => Reject("错误：已发货需走售后退货流程，不能直接取消");
        public override void OnEnter() => Console.WriteLine("进入状态：[已发货]");
    }
}