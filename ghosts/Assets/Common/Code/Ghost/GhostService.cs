using UnityEngine;
using Zenject;

namespace Common.Code.Ghost
{
    public class GhostService : IGhostService
    {
        private readonly IGhostFactory ghostFactory;
        private readonly GhostPool ghostPool;
        private GameObject ghost;
        
        [Inject]
        public GhostService(IGhostFactory ghostFactory, GhostPool ghostPool)
        {
            this.ghostFactory = ghostFactory;
            this.ghostPool = ghostPool;
            ghost = Resources.Load<GameObject>("Ghost");
        }

        public void Initialize()
        {
            ghostFactory.Create(ghost, new Vector3(0,0,0));
        }
    }
}