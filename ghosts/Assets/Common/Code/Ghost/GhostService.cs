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

        private void GhostPoolOnPoolInitialized()
        {
            ghostPool.PoolInitialized -= GhostPoolOnPoolInitialized;
            coroutineRunner.StartCoroutine(SpawnWithDelay());
        }

        private IEnumerator SpawnWithDelay()
        {
            var ghostCount = 0;
            do
            {
                CreateGhost();
                ghostCount++;
                yield return new WaitForSeconds(2f);
            } while (ghostCount < ghostSettings.GhostCount);
        }

        private void CreateGhost() => 
            ghostPool.GetFromPool(positionService.GetRandomPosition(new Vector3(-7, -6, 0), new Vector3(7, -6, 0)));
    }
}