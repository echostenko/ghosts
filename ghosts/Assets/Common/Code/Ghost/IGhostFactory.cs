using UnityEngine;

namespace Common.Code.Ghost
{
    public interface IGhostFactory
    {
        void Create(GameObject prefab, Vector3 position, Transform parent = null);
    }
}