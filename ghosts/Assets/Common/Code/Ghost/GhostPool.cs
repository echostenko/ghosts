using System;
using System.Collections.Generic;
using Common.Code.Data;
using UnityEngine;

namespace Common.Code.Ghost
{
    public class GhostPool
    {
        public event Action PoolInitialized;
        public List<GameObject> AvailableGhosts { get; } = new List<GameObject>();
        
        private readonly List<GameObject> usedGhosts = new List<GameObject>();
        private GameObject ghost;
        private readonly IGhostFactory ghostFactory;
        private readonly GhostSettings ghostSettings;

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
                var currentGhost = ghostFactory.Create(ghost, new Vector3(0, 0, 0));
                AvailableGhosts.Add(currentGhost);
            }
            
            PoolInitialized?.Invoke();
        }

        public GameObject GetFromPool(Vector3 position)
        {
            var currentGhost = AvailableGhosts[0];
            AvailableGhosts.Remove(currentGhost);
            usedGhosts.Add(currentGhost);
            currentGhost.transform.localPosition = position;
            currentGhost.SetActive(true);
            
            return currentGhost;
        }

        public void SetToPool(GameObject ghost)
        {
            ghost.SetActive(false);
            usedGhosts.Remove(ghost);
            AvailableGhosts.Add(ghost);
        }
    }
}