using Zenject;

namespace Common.Code.Ghost
{
    public class GhostService : IGhostService
    {
        private readonly GhostPool ghostPool;
        
        [Inject]
        public GhostService(GhostPool ghostPool) => 
            this.ghostPool = ghostPool;

        public void Initialize() => 
            ghostPool.PoolInitialized += GhostPoolOnPoolInitialized;

        private void GhostPoolOnPoolInitialized()
        {
            ghostPool.PoolInitialized -= GhostPoolOnPoolInitialized;

            for (var i = 0; i < ghostPool.AvailableGhosts.Count; i++) 
                ghostPool.GetFromPool();
        }
    }
}