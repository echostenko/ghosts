using JetBrains.Annotations;
using UnityEngine;

namespace Common.Code.Ghost
{
    [UsedImplicitly]
    public class GhostFactory : IGhostFactory
    {
        public GameObject Create(GameObject prefab, Vector3 position, Transform parent = null)
        {
            var ghost = Object.Instantiate(prefab, position, Quaternion.identity, parent);
            ghost.SetActive(false);
            return ghost;
        }
    }
}