using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachineDemo
{
    internal class OrderContext
    {
        private OrderStateBase _currentState;

        public OrderContext(OrderStateBase state)
        {
            _currentState = state;
            StateTransition(state);
        }

        public void StateTransition(OrderStateBase state)
        {
            if (state == null) throw new ArgumentNullException($"传入参数{nameof(state)}为空");

            if (_currentState == null)
            {
                Console.WriteLine($"初始化状态: {state.GetType().Name}");
            }
            else
            {
                Console.WriteLine($"状态更新:{_currentState?.GetType().Name}->{state?.GetType().Name}");
            }
            _currentState!.OnExit();
            _currentState = state!;
            _currentState.SetContext(this);
            _currentState.OnEnter();

        }
        public void TriggerPay() => _currentState.HandlePay();
        public void TriggerShip() => _currentState.HandleShip();
        public void TriggerConfirm() => _currentState.HandleConfirm();
        public void TriggerCancel() => _currentState.HandleCancel();
    }
}
