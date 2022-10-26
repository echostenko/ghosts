using Common.Code.Services;
using Zenject;

namespace Common.Code.StateMachine.States
{
    public class InitializeState: IState
    {
        private readonly ScenesService scenesService;
        private readonly IGameStateMachine gameStateMachine;

        [Inject]
        public InitializeState(ScenesService scenesService, IGameStateMachine gameStateMachine)
        {
            this.scenesService = scenesService;
            this.gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            scenesService.Initialize();
        }

        public void Exit()
        {
        }
    }
}