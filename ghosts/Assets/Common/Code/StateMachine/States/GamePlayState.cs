using Common.Code.Ghost;
using Zenject;

namespace Common.Code.StateMachine.States
{
    public class GamePlayState: IState
    {
        private readonly IGhostService ghostService;
        private readonly GhostPool ghostPool;

        [Inject]
        public GamePlayState(IGhostService ghostService, GhostPool ghostPool)
        {
            this.ghostService = ghostService;
            this.ghostPool = ghostPool;
        }
        public void Enter()
        {
            ghostPool.Initialize();
            ghostService.Initialize();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}