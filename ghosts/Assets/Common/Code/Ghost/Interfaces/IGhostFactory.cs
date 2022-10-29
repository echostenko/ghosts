using UnityEngine;

namespace Common.Code.Ghost.Interfaces
{
    public interface IGhostFactory
    {
        GhostBehaviour Create(GameObject prefab, Vector3 position, Transform parent = null);
    }
}