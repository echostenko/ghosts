using Common.Code.StateMachine.Factory;
using Common.Code.StateMachine.States;
using JetBrains.Annotations;
using Zenject;

namespace Common.Code.StateMachine
{
    [UsedImplicitly]
    public class GameStateMachine: IGameStateMachine
    {
        private IStatesFactory gameStatesFactory;
        private IState currentState;

        [Inject]
        public void SetDependencies(IStatesFactory gameStatesFactory) =>
            this.gameStatesFactory = gameStatesFactory;

        public void Enter<T>() where T : IState
        {
            Exit();
            currentState = gameStatesFactory.GetState(typeof(T));
            currentState.Enter();
        }

        public void Exit() =>
            currentState?.Exit();
    }
}