using UnityEngine;

namespace Common.Code.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "GhostSettings")]
    public class GhostSettings: ScriptableObject
    {
        public int GhostCount;
    }
}