using System;
using System.Collections;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayCycle: IDisposable
    {
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _inputArgs;
        private GameMode _gameMode;
        
        private bool _isGameOver;

        public GameplayCycle(DIContainer container, GameplayInputArgs inputArgs)
        {
            _container = container;
            _inputArgs = inputArgs;
        }

        public IEnumerator Prepare()
        {
            _gameMode = new GameMode(_container, _inputArgs);
            
            yield return null;
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
            
            if (_isGameOver && Input.GetKeyDown(KeyCode.Space))
            {
                SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
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
            }
            
            _isGameOver = true;
            
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