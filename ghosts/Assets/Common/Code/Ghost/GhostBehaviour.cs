using DG.Tweening;
using UnityEngine;

namespace Common.Code.Ghost
{
    public class GhostBehaviour : MonoBehaviour
    {
        public void Start() => 
            transform.DOMoveY(50f, 10f);
    }
}