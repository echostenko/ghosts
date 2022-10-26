using System;
using UnityEngine;

namespace Common.Code.Input
{
    public class StartButton: MonoBehaviour, IStartButton
    {
        public event Action OnStartButtonClicked;
        
        private void OnClick() => 
            OnStartButtonClicked?.Invoke();
    }
}