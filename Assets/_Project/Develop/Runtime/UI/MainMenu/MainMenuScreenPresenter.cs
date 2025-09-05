using System.Collections.Generic;
using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Score;
using _Project.Develop.Runtime.UI.Wallet;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter: IPresenter
    {
        private readonly MainMenuScreenView _screen;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly SceneSwitcherService _sceneSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly LevelsListConfig _levelListConfig;
        
        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            SceneSwitcherService sceneSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            LevelsListConfig levelListConfig
        ) {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _sceneSwitcherService = sceneSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _levelListConfig = levelListConfig;
        }

        public void Initialize()
        {
            _screen.PlayButtonClicked += PlayButtonClicked;
            
            CreateWallet();
            CreateScore();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.PlayButtonClicked += PlayButtonClicked;
            
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void PlayButtonClicked()
        {
            _coroutinesPerformer
                .StartPerform(_sceneSwitcherService
                    .ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(Random.Range(1, _levelListConfig.Levels.Count))));
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);
            _childPresenters.Add(walletPresenter);
        }
        
        private void CreateScore()
        {
            ScoreListPresenter scoreListPresenter = _projectPresentersFactory.CreateScoreListPresenter(_screen.ScoreListView);
            _childPresenters.Add(scoreListPresenter);
        }
    }
}