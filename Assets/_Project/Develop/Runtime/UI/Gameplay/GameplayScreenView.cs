using System;
using _Project.Develop.Runtime.UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayScreenView: MonoBehaviour, IView
    {
        public event Action StartWaveButtonClicked;
        
        [SerializeField] private Button _startWaveButton;

        private void OnEnable()
        {
            _startWaveButton.onClick.AddListener(OnStartWaveButtonClicked);
        }

        private void OnStartWaveButtonClicked() => StartWaveButtonClicked?.Invoke();

        private void OnDisable()
        {
            _startWaveButton.onClick.RemoveListener(OnStartWaveButtonClicked);
        }
    }
}