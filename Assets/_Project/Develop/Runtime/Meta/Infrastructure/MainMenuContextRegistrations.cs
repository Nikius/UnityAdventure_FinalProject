using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.UI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.MainMenu;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresenterFactory);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPopupService);
        }

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer c)
        {
            return new MainMenuPopupService(
                c.Resolve<ViewsFactory>(),
                c.Resolve<ProjectPresenterFactory>(),
                c.Resolve<MainMenuUIRoot>()
            );
        }
        
        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer c)
        {
            MainMenuUIRoot menuUIRootPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<MainMenuUIRoot>("UI/MainMenu/MainMenuUIRoot");

            return Object.Instantiate(menuUIRootPrefab);
        }

        public static MainMenuPresenterFactory CreateMainMenuPresenterFactory(DIContainer c)
        {
            return new MainMenuPresenterFactory(c);
        }

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer c)
        {
            MainMenuUIRoot uiRoot = c.Resolve<MainMenuUIRoot>();
            
            MainMenuScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<MainMenuScreenView>(ViewIDs.MainMenuScreen, uiRoot.HUDLayer);

            MainMenuScreenPresenter presenter = c
                .Resolve<MainMenuPresenterFactory>()
                .CreateMainMenuScreen(view);
            
            return presenter;
        }
    }
}