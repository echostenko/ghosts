using System;
using System.Collections.Generic;
using Common.Code.StateMachine.States;
using Zenject;

namespace Common.Code.StateMachine.Factory
{
    public class StatesFactory : IStatesFactory
    {
        private Dictionary<Type, IState> states;
        private readonly IState initializeState;
        private readonly IState gamePlayState;

        [Inject]
        public StatesFactory(
            [Inject(Id = "InitializeState")] IState initializeState,
            [Inject(Id = "GamePlayState")] IState gamePlayState)

        {
            this.initializeState = initializeState;
            this.gamePlayState = gamePlayState;
            SetDependencies();
        }

        private void SetDependencies()
        {
            states = new Dictionary<Type, IState>
            {
                [typeof(InitializeState)] = initializeState,
                [typeof(GamePlayState)] = gamePlayState
            };
        }

        public IState GetState(Type state) =>
            states[state];
    }
}