namespace StateMachineDemo
{
    internal class CancelledState : OrderStateBase
    {
        public override void HandlePay() => Reject("订单已取消，无操作");
        public override void HandleShip() => Reject("订单已取消，无操作");
        public override void HandleConfirm() => Reject("订单已取消，无操作");
        public override void HandleCancel() => Reject("订单已取消，无操作");

        public override void OnEnter() => Console.WriteLine("进入状态：[已取消]");
    }
}