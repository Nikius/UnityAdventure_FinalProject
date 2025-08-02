using System.Collections.Generic;
using _Project.Develop.Runtime.Meta.Service;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Score;
using _Project.Develop.Runtime.UI.Wallet;
using _Project.Develop.Runtime.Utilities.DataManagement;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter: IPresenter
    {
        private readonly MainMenuScreenView _screen;
        
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        
        private readonly MainMenuPopupService _popupService;
        private readonly ResetScoresService _resetScoresService;
        private readonly AutosaveService _autosaveService;
        
        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService, ResetScoresService resetScoresService, AutosaveService autosaveService) {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
            _resetScoresService = resetScoresService;
            _autosaveService = autosaveService;
        }

        public void Initialize()
        {
            _screen.OpenLevelsMenuButtonClicked += OpenLevelsMenuButtonClicked;
            _screen.ResetScoresButtonClicked += ResetScoresButtonClicked;
            
            CreateWallet();
            CreateScoreList();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OpenLevelsMenuButtonClicked;
            _screen.ResetScoresButtonClicked -= ResetScoresButtonClicked;
            
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void OpenLevelsMenuButtonClicked()
        {
            _popupService.OpenLevelsMenuPopup();
        }

        private void ResetScoresButtonClicked()
        {
            _resetScoresService.ResetScore();
            _autosaveService.Run();
        }
        
        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screen.WalletView);
            _childPresenters.Add(walletPresenter);
        }

        private void CreateScoreList()
        {
            ScoreListPresenter scoreListPresenter = _projectPresentersFactory.CreateScoreListPresenter(_screen.ScoreListView);
            _childPresenters.Add(scoreListPresenter);
        }
    }
}