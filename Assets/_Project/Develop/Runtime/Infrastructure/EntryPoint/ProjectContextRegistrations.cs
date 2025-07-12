using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.AssetsManagement;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.LoadingScreen;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class ProjectContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
            container.RegisterAsSingle(CreateConfigsProviderService);
            container.RegisterAsSingle(CreateResourcesAssetsLoader);
            container.RegisterAsSingle(CreateSceneLoaderService);
            container.RegisterAsSingle<ILoadingScreen>(CreateLoadingScreen);
            container.RegisterAsSingle(CreateSceneSwitcherService);
            container.RegisterAsSingle(CreateWalletService);
        }

        private static WalletService CreateWalletService(DIContainer c)
        {
            Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new();

            foreach (CurrencyTypes currencyTypes in Enum.GetValues(typeof(CurrencyTypes)))
                currencies[currencyTypes] = new ReactiveVariable<int>();
            
            return new WalletService(currencies);
        }

        private static SceneSwitcherService CreateSceneSwitcherService(DIContainer c)
            => new (c.Resolve<SceneLoaderService>(), c.Resolve<ILoadingScreen>(), c);

        private static SceneLoaderService CreateSceneLoaderService(DIContainer c) => new();
        
        private static ConfigsProviderService CreateConfigsProviderService(DIContainer c)
        {
            ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(c.Resolve<ResourcesAssetsLoader>());
            
            return new ConfigsProviderService(resourcesConfigsLoader);
        }

        private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer c) => new();

        private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer c)
        {
            CoroutinesPerformer coroutinesPerformerPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

            return Object.Instantiate(coroutinesPerformerPrefab);
        }
        
        private static StandardLoadingScreen CreateLoadingScreen(DIContainer c)
        {
            StandardLoadingScreen standardLoadingScreenPrefab = c.Resolve<ResourcesAssetsLoader>()
                .Load<StandardLoadingScreen>("Utilities/StandardLoadingScreen");

            return Object.Instantiate(standardLoadingScreenPrefab);
        }
    }
}