using System;
using System.Collections;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap: SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        
        private WalletService _walletService;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");
            
            _inputArgs = gameplayInputArgs;
            
            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log($"Current level: {_inputArgs.LevelNumber}");
            
            _walletService = _container.Resolve<WalletService>();
            
            Debug.Log("GameplayBootstrap initialized");
            
            yield break;
        }

        public override void Run()
        {
            Debug.Log("GameplayBootstrap running...");
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
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