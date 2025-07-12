using System;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameMode
    {
        public event Action Win;
        public event Action Defeat;
        
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _inputArgs;
        
        private bool _isRunning;
        
        private string _stringForType;
        private string _userInput;

        public GameMode(DIContainer container, GameplayInputArgs inputArgs)
        {
            _container = container;
            _inputArgs = inputArgs;
        }

        public void Start()
        {
            _isRunning = true;
            _stringForType = GenerateString();
            
            Debug.Log($"Type this string: {_stringForType}");
        }

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;
            
            if (!string.IsNullOrEmpty(Input.inputString) && _stringForType != null)
            {
                _userInput += Input.inputString;
                
                if (DefeatConditionCompleted())
                {
                    ProcessDefeat();
                    return;
                }

                if (WinConditionCompleted())
                {
                    ProcessWin();
                    return;
                }
            }
        }
        
        private void ProcessEndGame()
        {
            _isRunning = false;
        }

        private void ProcessDefeat()
        {
            ProcessEndGame();
            Defeat?.Invoke();
        }

        private void ProcessWin()
        {
            ProcessEndGame();
            Win?.Invoke();
        }

        private bool WinConditionCompleted()
        {
            return _userInput == _stringForType;
        }

        private bool DefeatConditionCompleted()
        {
            return _stringForType.IndexOf(_userInput) != 0;
        }
        
        private string GenerateString()
        {
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();
            StringGeneratorService stringGeneratorService = _container.Resolve<StringGeneratorService>();

            GameModesConfig gameModesConfig = configsProviderService.GetConfig<GameModesConfig>();
            
            string symbolsSet = gameModesConfig.SymbolsSets[_inputArgs.SymbolsSetIndex];
            
            return stringGeneratorService.GenerateString(gameModesConfig.LengthOfStringForType, symbolsSet);
        }
    }
}