using UnityEngine;

namespace Common.Code.Ghost
{
    public interface IGhostFactory
    {
        GhostBehaviour Create(GameObject prefab, Vector3 position, Transform parent = null);
    }
}