using System;
using _Project.Develop.Runtime.UI.CommonViews;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Score;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView: MonoBehaviour, IView
    {
        public event Action PlayButtonClicked;
        
        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public ScoreListView ScoreListView { get; private set; }
        [SerializeField] private Button _playButton;

        private void OnEnable()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked() => PlayButtonClicked?.Invoke();

        private void OnDisable()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }
    }
}