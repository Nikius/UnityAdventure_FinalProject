using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.UI.Core;
using _Project.Develop.Runtime.UI.Gameplay;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayContextRegistrations
    {
        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            container.RegisterAsSingle(CreateGameplayUIRoot).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresenterFactory);
            container.RegisterAsSingle(CreateUserInputService);
            container.RegisterAsSingle(CreateGameTaskService);
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
        }
        
        private static UserInputService CreateUserInputService(DIContainer c)
        {
            return new UserInputService(new ReactiveVariable<string>());
        }

        private static GameTaskService CreateGameTaskService(DIContainer c)
        {
            return new GameTaskService(new ReactiveVariable<string>());
        }
        
        private static GameplayUIRoot CreateGameplayUIRoot(DIContainer c)
        {
            GameplayUIRoot menuUIRootPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<GameplayUIRoot>("UI/Gameplay/GameplayUIRoot");

            return Object.Instantiate(menuUIRootPrefab);
        }

        private static GameplayPresenterFactory CreateGameplayPresenterFactory(DIContainer c)
        {
            return new GameplayPresenterFactory(c);
        }

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer c)
        {
            GameplayUIRoot uiRoot = c.Resolve<GameplayUIRoot>();
            
            GameplayScreenView view = c
                .Resolve<ViewsFactory>()
                .Create<GameplayScreenView>(ViewIDs.GameplayScreen, uiRoot.HUDLayer);

            GameplayScreenPresenter presenter = c
                .Resolve<GameplayPresenterFactory>()
                .CreateGameplayScreen(view);
            
            return presenter;
        }
    }
}