using System;
using System.Collections;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Gameplay.Controllers;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Meta.Features.Score;
using _Project.Develop.Runtime.Meta.Features.Wallet;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.DataManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle: IDisposable
    {
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _inputArgs;
        private GameMode _gameMode;
        private RestartController _restartController;
        private ScoreService _scoreService;
        private WalletService _walletService;
        private GameModesConfig _gameModesConfig;
        
        private bool _isGameOver;

        public GameplayCycle(DIContainer container, GameplayInputArgs inputArgs)
        {
            _container = container;
            _inputArgs = inputArgs;
        }

        public IEnumerator Prepare()
        {
            _gameMode = new GameMode(_container, _inputArgs);
            _restartController = new RestartController(_container);
            _scoreService = _container.Resolve<ScoreService>();
            _walletService = _container.Resolve<WalletService>();
            
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();
            _gameModesConfig = configsProviderService.GetConfig<GameModesConfig>();
            
            yield break;
        }
        
        public void Launch()
        {
            _gameMode.Win += OnGameModeWin;
            _gameMode.Defeat += OnGameModeDefeat;

            _gameMode.Start();
        }

        public void Update(float deltaTime)
        {
            _gameMode?.Update(deltaTime);
            _restartController?.Update(deltaTime);
        } 
        
        public void Dispose()
        {
            if (_isGameOver == false)
                OnGameModeEnded();
        }

        private void OnGameModeEnded()
        {
            DisposeGameMode();
            
            _isGameOver = true;
            _restartController.Enable();
            
            RunAutosave();

            Debug.Log("Press Space to restart the game.");
        }

        private void DisposeGameMode()
        {
            if(_gameMode != null)
            {
                _gameMode.Win -= OnGameModeWin;
                _gameMode.Defeat -= OnGameModeDefeat;
                
                _gameMode.Dispose();
            }
        }

        private void RunAutosave()
        {
            AutosaveService autosaveService = _container.Resolve<AutosaveService>();
            autosaveService.Run();
        }

        private void OnGameModeDefeat()
        {
            Debug.Log("Defeat");
            
            IncreaseLoosesCount();
            AddPenalty();
            
            OnGameModeEnded();
        }

        private void OnGameModeWin()
        {
            Debug.Log("Win");
            
            IncreaseWinsCount();
            AddReward();
            
            OnGameModeEnded();
        }

        private void AddPenalty()
        {
            CurrencyTypes currencyType = _gameModesConfig.Penalty.Type;
            int penaltyValue = _gameModesConfig.Penalty.Value;
            
            if (_walletService.Enough(currencyType, penaltyValue))
                _walletService.Spend(currencyType, penaltyValue);
            else
                _walletService.Spend(currencyType, _walletService.GetCurrency(currencyType).Value);
        }

        private void AddReward() => _walletService.Add(_gameModesConfig.Reward.Type, _gameModesConfig.Reward.Value);

        private void IncreaseWinsCount() => _scoreService.IncreaseWins();
        private void IncreaseLoosesCount() => _scoreService.IncreaseLooses();
    }
}