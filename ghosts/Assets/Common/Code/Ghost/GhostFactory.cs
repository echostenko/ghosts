using UnityEngine;

namespace Common.Code.Ghost
{
    public class GhostFactory : IGhostFactory
    {
        public void Create(GameObject prefab, Vector3 position, Transform parent = null) => 
            Object.Instantiate(prefab, position, Quaternion.identity, parent);
    }
}