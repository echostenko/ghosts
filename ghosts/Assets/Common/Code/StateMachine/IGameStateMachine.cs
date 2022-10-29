using Common.Code.StateMachine.States;

namespace Common.Code.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<T>() where T : IState;
        void Exit();
    }
}