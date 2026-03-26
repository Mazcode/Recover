namespace StateMachineDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new OrderContext(new CreatedState());

            order.TriggerPay();      // Created -> Paid
            order.TriggerShip();     // Paid -> Shipped
            order.TriggerCancel();   // Shipped -> 拒绝
            order.TriggerConfirm();  // Shipped -> Completed

            Console.WriteLine("\n--- 新建一个订单并取消 ---");
            var order2 = new OrderContext(new CreatedState());
            order2.TriggerCancel();  // Created -> Cancelled
            order2.TriggerPay();     // Cancelled -> 拒绝
        }
    }
}
