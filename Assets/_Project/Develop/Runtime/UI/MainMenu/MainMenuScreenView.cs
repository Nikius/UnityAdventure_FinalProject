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
        public event Action OpenLevelsMenuButtonClicked;
        public event Action ResetScoresButtonClicked;
        
        [field: SerializeField] public IconTextListView WalletView { get; private set; }
        [field: SerializeField] public ScoreListView ScoreListView { get; private set; }
        [SerializeField] private Button _openLevelsMenuButton;
        [SerializeField] private Button _resetScoresButton;

        private void OnEnable()
        {
            _openLevelsMenuButton.onClick.AddListener(OnOpenLevelsMenuButtonClicked);
            _resetScoresButton.onClick.AddListener(OnResetScoresButtonClicked);
        }

        private void OnDisable()
        {
            _openLevelsMenuButton.onClick.RemoveListener(OnOpenLevelsMenuButtonClicked);
            _resetScoresButton.onClick.RemoveListener(OnResetScoresButtonClicked);
        }

        private void OnOpenLevelsMenuButtonClicked() => OpenLevelsMenuButtonClicked?.Invoke();

        private void OnResetScoresButtonClicked() => ResetScoresButtonClicked?.Invoke();
    }
}