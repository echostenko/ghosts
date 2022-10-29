using System;
using System.Collections.Generic;
using Common.Code.Data;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Common.Code.Ghost
{
    [UsedImplicitly]
    public class GhostPool
    {
        public event Action PoolInitialized;
        public event Action GhostAddedToPool;
        private List<GhostBehaviour> AvailableGhosts { get; } = new List<GhostBehaviour>();
        private readonly List<GhostBehaviour> usedGhosts = new List<GhostBehaviour>();
        private GameObject ghost;
        private readonly IGhostFactory ghostFactory;
        private readonly GhostSettings ghostSettings;

        [Inject]
        public GhostPool(IGhostFactory ghostFactory, GhostSettings ghostSettings)
        {
            this.ghostFactory = ghostFactory;
            this.ghostSettings = ghostSettings;
            ghost = Resources.Load<GameObject>("Ghost");
        }
        
        public void Initialize()
        {
            for (var i = 0; i < ghostSettings.GhostCount; i++)
            {
                var currentGhost = ghostFactory.Create(ghost, Vector3.zero);
                AvailableGhosts.Add(currentGhost);
            }
            
            PoolInitialized?.Invoke();
        }

        public GhostBehaviour GetFromPool(Vector3 position)
        {
            var rand = Random.Range(0, AvailableGhosts.Count);
            var currentGhost = AvailableGhosts[rand];
            AvailableGhosts.Remove(currentGhost);
            usedGhosts.Add(currentGhost);
            currentGhost.transform.position = position;
            currentGhost.gameObject.SetActive(true);
            currentGhost.gameObject.GetComponent<GhostBehaviour>().Move();
            
            return currentGhost;
        }

        public void SetToPool(GhostBehaviour ghost)
        {
            AvailableGhosts.Add(ghost);
            ghost.gameObject.SetActive(false);
            usedGhosts.Remove(ghost);
            GhostAddedToPool?.Invoke();
        }
    }
}