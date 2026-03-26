namespace StateMachineDemo
{
    internal abstract class OrderStateBase
    {
        protected OrderContext? context =null;

        public void SetContext(OrderContext context) => this.context = context;

        public abstract void HandlePay();//抽象方法，子类必须实现
        public abstract void HandleShip();
        public abstract void HandleConfirm();
        public abstract void HandleCancel();

        public virtual void OnEnter() { }//virtual修饰的虚方法，子类可以选择重写或者不重写
        //当父类的实现，不满足子类的实际需求时候，子类可以选择重写方法里面的逻辑

        public virtual void OnExit() { }

        protected virtual void Reject(string? message)
        {
            Console.WriteLine($"当前{this.GetType()}状态不能执行.{(!string.IsNullOrEmpty(message) ? $"原因：{message}" : "")}");
        }
    }
}