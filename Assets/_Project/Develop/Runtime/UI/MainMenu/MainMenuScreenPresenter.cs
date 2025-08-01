using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Score;
using _Project.Develop.Runtime.UI.Wallet;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter: IPresenter
    {
        private readonly MainMenuScreenView _screen;
        
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        
        private readonly MainMenuPopupService _popupService;
        
        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresentersFactory projectPresentersFactory,
            MainMenuPopupService popupService
        ) {
            _screen = screen;
            _projectPresentersFactory = projectPresentersFactory;
            _popupService = popupService;
        }

        public void Initialize()
        {
            _screen.OpenLevelsMenuButtonClicked += OpenLevelsMenuButtonClicked;
            
            CreateWallet();
            CreateScoreList();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenLevelsMenuButtonClicked -= OpenLevelsMenuButtonClicked;
            
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void OpenLevelsMenuButtonClicked()
        {
            _popupService.OpenLevelsMenuPopup();
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