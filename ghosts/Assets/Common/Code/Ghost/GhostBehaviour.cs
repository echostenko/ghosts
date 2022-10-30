using System;
using Common.Code.Score;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.Code.Ghost
{
    public class GhostBehaviour : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Animator animator;
        [SerializeField] private ScoreBehaviour scoreBehaviour;
        
        private ScoreBehaviour score;
        private TweenerCore<Vector3, Vector3, VectorOptions> tween;
        private const string ClickTriggerName = "click";
        private readonly int click = Animator.StringToHash(ClickTriggerName);
        public event EventHandler<GhostBehaviour> GhostOnFinish;
        public event EventHandler<GhostBehaviour> GhostOnClick;

        public void Move()
        {
            tween = transform.DOMoveY(10f, 3f).SetSpeedBased().SetEase(Ease.Linear);
            tween.onComplete += OnComplete;
        }

        public void OnPointerClick(PointerEventData eventData) => 
            animator.SetTrigger(click);

        [UsedImplicitly]
        public void SendEventGhostKilled()
        {
            GhostOnClick?.Invoke(this, this);
            score.AddPoint();
            gameObject.SetActive(false);
            tween.Kill();
        }

        private void Awake() => 
            score = scoreBehaviour.GetInstance();

        private void OnComplete() => 
            GhostOnFinish?.Invoke(this, this);
    }
}