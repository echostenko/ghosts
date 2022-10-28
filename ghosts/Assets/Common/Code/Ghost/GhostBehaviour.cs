using System;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Code.Ghost
{
    public class GhostBehaviour : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Animator animator;
        private const string ClickTriggerName = "click";
        private readonly int click = Animator.StringToHash(ClickTriggerName);
        public event EventHandler<GhostBehaviour> GhostOnFinish;
        public event EventHandler<GhostBehaviour> GhostOnClick;

        public void Move() => 
            transform.DOMoveY(10f, 3f).SetSpeedBased().SetEase(Ease.Linear).onComplete += OnComplete;

        public void OnPointerClick(PointerEventData eventData) => 
            animator.SetTrigger(click);

        [UsedImplicitly]
        public void SendEventGhostKilled()
        {
            GhostOnClick?.Invoke(this, this);
            gameObject.SetActive(false);
        }

        private void OnComplete() => 
            GhostOnFinish?.Invoke(this, this);
    }
}