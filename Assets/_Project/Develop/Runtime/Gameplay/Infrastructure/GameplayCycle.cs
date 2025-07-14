using System;
using System.Collections;
using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Gameplay.Controllers;
using _Project.Develop.Runtime.Infrastructure.DI;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle: IDisposable
    {
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _inputArgs;
        private GameMode _gameMode;
        private RestartController _restartController;
        
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
            if(_gameMode != null)
            {
                _gameMode.Win -= OnGameModeWin;
                _gameMode.Defeat -= OnGameModeDefeat;
                
                _gameMode.Dispose();
            }
            
            _isGameOver = true;
            _restartController.Enable();
            
            Debug.Log("Press Space to restart the game.");
        }
        
        private void OnGameModeDefeat()
        {
            Debug.Log("Defeat");
            
            OnGameModeEnded();
        }

        private void OnGameModeWin()
        {
            Debug.Log("Win");
            
            OnGameModeEnded();
        }
    }
}