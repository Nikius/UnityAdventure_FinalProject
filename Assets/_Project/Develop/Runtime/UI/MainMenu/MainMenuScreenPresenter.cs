using System.Collections.Generic;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Wallet;

namespace _Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter: IPresenter
    {
        private readonly MainMenuScreenView _screen;
        
        private readonly ProjectPresenterFactory _projectPresenterFactory;
        
        private readonly MainMenuPopupService _popupService;
        
        private readonly List<IPresenter> _childPresenters = new();

        public MainMenuScreenPresenter(
            MainMenuScreenView screen,
            ProjectPresenterFactory projectPresenterFactory,
            MainMenuPopupService popupService
        ) {
            _screen = screen;
            _projectPresenterFactory = projectPresenterFactory;
            _popupService = popupService;
        }

        public void Initialize()
        {
            _screen.OpenTestPopupButtonClicked += OpenTestPopupButtonClicked;
            
            CreateWallet();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screen.OpenTestPopupButtonClicked -= OpenTestPopupButtonClicked;
            
            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();
            
            _childPresenters.Clear();
        }

        private void OpenTestPopupButtonClicked()
        {
            _popupService.OpenTestPopup();
        }

        private void CreateWallet()
        {
            WalletPresenter walletPresenter = _projectPresenterFactory.CreateWalletPresenter(_screen.WalletView);
            _childPresenters.Add(walletPresenter);
        }
    }
}