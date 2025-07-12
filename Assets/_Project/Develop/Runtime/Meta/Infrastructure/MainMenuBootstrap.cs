using System.Collections;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Meta.Controllers;
using _Project.Develop.Runtime.Utilities.DataManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap: SceneBootstrap
    {
        private DIContainer _container;
        
        private WalletService _walletService;
        private SelectSymbolsSetController _selectSymbolsSetController;
        
        private bool _isRunning;
        
        private PlayerData _playerData;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("MainMenuBootstrap initialized");
            
            _walletService = _container.Resolve<WalletService>();
            
            _selectSymbolsSetController = new SelectSymbolsSetController(_container);
            
            _selectSymbolsSetController.Initialize();
            
            _playerData = new PlayerData();
            _playerData.WalletData = new Dictionary<CurrencyTypes, int>()
            {
                { CurrencyTypes.Gold, 5 },
                { CurrencyTypes.Diamond, 10 }
            };

            yield break;
        }

        public override void Run()
        {
            _selectSymbolsSetController.ShowSelectRequest();

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;

            _selectSymbolsSetController.Update();
        }
        
        private void OnDestroy() => Dispose();

        public override void Dispose()
        {
            //
        }
    }
}