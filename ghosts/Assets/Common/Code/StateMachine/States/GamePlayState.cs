using Common.Code.Ghost;
using Zenject;

namespace Common.Code.StateMachine.States
{
    public class GamePlayState: IState
    {
        private readonly IGhostSpawner ghostSpawner;

        [Inject]
        public GamePlayState(IGhostSpawner ghostSpawner)
        {
            this.ghostSpawner = ghostSpawner;
        }
        public void Enter()
        {
            ghostSpawner.Initialize();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }
    }
}