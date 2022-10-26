using Common.Code.StateMachine;
using Common.Code.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Common.Code
{
    public class BootStrap: MonoBehaviour
    {
        private IGameStateMachine gameStateMachine;
        
        [Inject]
        private void SetDependencies(IGameStateMachine gameStateMachine)
        {
            this.gameStateMachine = gameStateMachine;
            gameStateMachine.Enter<InitializeState>();
        }
    }
}