using System.Collections.Generic;
using Common.Code.Data;
using UnityEngine;

namespace Common.Code.Ghost
{
    public class GhostPool
    {
        public List<GameObject> Ghosts = new List<GameObject>();

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
                Ghosts.Add(currentGhost);
                currentGhost.SetActive(false);
            }
        }
    }
}