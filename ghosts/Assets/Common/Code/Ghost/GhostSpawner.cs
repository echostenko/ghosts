using UnityEngine;
using Zenject;

namespace Common.Code.Ghost
{
    public class GhostSpawner : IGhostSpawner
    {
        private readonly IGhostFactory ghostFactory;
        private GameObject ghost;
        
        [Inject]
        public GhostSpawner(IGhostFactory ghostFactory)
        {
            this.ghostFactory = ghostFactory;
            ghost = Resources.Load<GameObject>("Ghost");
        }

        public void Initialize()
        {
            ghostFactory.Create(ghost, new Vector3(0,0,0));
        }
    }
}