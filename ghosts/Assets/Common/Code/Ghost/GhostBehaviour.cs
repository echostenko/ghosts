using System;
using DG.Tweening;
using UnityEngine;

namespace Common.Code.Ghost
{
    public class GhostBehaviour : MonoBehaviour
    {
        public event EventHandler<GhostBehaviour> GhostOnFinish;
        
        public void Move() => 
            transform.DOMoveY(10f, 3f).SetSpeedBased().SetEase(Ease.Linear).onComplete += ONComplete;

        private void ONComplete() => 
            GhostOnFinish?.Invoke(this, this);
    }
}