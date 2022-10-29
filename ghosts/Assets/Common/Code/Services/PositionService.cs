using UnityEngine;

namespace Common.Code.Services
{
    public class PositionService
    {
        public Vector3 GetRandomPosition(Vector3 leftBound, Vector3 rightBound) => 
            new Vector3(Random.Range(leftBound.x, rightBound.x), leftBound.y, leftBound.z);
    }
}