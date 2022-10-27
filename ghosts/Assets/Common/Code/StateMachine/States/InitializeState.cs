using Common.Code.Services;
using Zenject;

namespace Common.Code.StateMachine.States
{
    public class InitializeState: IState
    {
        private readonly ScenesService scenesService;

        [Inject]
        public InitializeState(ScenesService scenesService) => 
            this.scenesService = scenesService;

        public void Enter() => 
            scenesService.Initialize();

        public void Exit()
        {
        }
    }
}