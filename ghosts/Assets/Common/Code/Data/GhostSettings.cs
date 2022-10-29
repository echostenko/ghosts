using UnityEngine;

namespace Common.Code.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GhostSettings")]
    public class GhostSettings: ScriptableObject
    {
        public int GhostCount;
        public Vector3 LeftBound;
        public Vector3 RightBound;
        public float SpawnDelay;
    }
}