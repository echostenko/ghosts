using System.Collections;
using Common.Code.Data;
using Common.Code.Services;
using UnityEngine;
using Zenject;

namespace Common.Code.Ghost
{
    public class GhostService : IGhostService
    {
        private readonly GhostPool ghostPool;
        private readonly ICoroutineRunner coroutineRunner;
        private readonly GhostSettings ghostSettings;
        private readonly PositionService positionService = new PositionService();

        [Inject]
        public GhostService(GhostPool ghostPool, ICoroutineRunner coroutineRunner, GhostSettings ghostSettings)
        {
            this.ghostPool = ghostPool;
            this.coroutineRunner = coroutineRunner;
            this.ghostSettings = ghostSettings;
        }

        public void Initialize() => 
            ghostPool.PoolInitialized += GhostPoolOnPoolInitialized;

        public void UnSubscribe() => 
            ghostPool.GhostAddedToPool -= CreateGhost;

        private void GhostPoolOnPoolInitialized()
        {
            ghostPool.PoolInitialized -= GhostPoolOnPoolInitialized;
            coroutineRunner.StartCoroutine(SpawnWithDelay());
            ghostPool.GhostAddedToPool += CreateGhost;
        }

        private IEnumerator SpawnWithDelay()
        {
            var ghostCount = 0;
            do
            {
                CreateGhost();
                ghostCount++;
                yield return new WaitForSeconds(ghostSettings.SpawnDelay);
            } while (ghostCount < ghostSettings.GhostCount);
        }

        private void CreateGhost()
        {
            var ghostBehaviour = ghostPool.GetFromPool(positionService.
                GetRandomPosition(ghostSettings.LeftBound, ghostSettings.RightBound));
            ghostBehaviour.GhostOnFinish += GhostBehaviourOnGhostOnFinish;
            ghostBehaviour.GhostOnClick += GhostBehaviourOnGhostOnFinish;
        }

        private void GhostBehaviourOnGhostOnFinish(object sender, GhostBehaviour currentGhost)
        {
            currentGhost.GhostOnFinish -= GhostBehaviourOnGhostOnFinish;
            currentGhost.GhostOnClick -= GhostBehaviourOnGhostOnFinish;
            ghostPool.SetToPool(currentGhost);
        }
    }
}