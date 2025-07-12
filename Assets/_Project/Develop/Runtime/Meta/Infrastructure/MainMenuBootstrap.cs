using System.Collections;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap: SceneBootstrap
    {
        private DIContainer _container;
        
        private WalletService _walletService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("MainMenuBootstrap initialized");
            
            _walletService = _container.Resolve<WalletService>();
            
            yield break;
        }

        public override void Run()
        {
            Debug.Log("MainMenuBootstrap running...");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(2)));
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _walletService.Add(CurrencyTypes.Gold, 10);
                Debug.Log("Gold: " + _walletService.GetCurrency(CurrencyTypes.Gold).Value);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (_walletService.Enough(CurrencyTypes.Gold, 10) == false)
                    return;
                
                _walletService.Spend(CurrencyTypes.Gold, 10);
                Debug.Log("Gold: " + _walletService.GetCurrency(CurrencyTypes.Gold).Value);
            }
        }
    }
}