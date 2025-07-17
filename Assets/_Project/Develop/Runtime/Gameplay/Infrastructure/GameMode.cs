using System;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Gameplay.Controllers;
using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameMode: IDisposable
    {
        public event Action Win;
        public event Action Defeat;
        
        private readonly DIContainer _container;
        private readonly GameplayInputArgs _inputArgs;
        private UserInputValidationService _userInputValidationService;
        private UserInputController _userInputController;
        
        private bool _isRunning;
        
        private string _stringForType;

        public GameMode(DIContainer container, GameplayInputArgs inputArgs)
        {
            _container = container;
            _inputArgs = inputArgs;
        }

        public void Start()
        {
            _isRunning = true;

            _stringForType = GenerateString();
            
            _userInputValidationService = new UserInputValidationService(_stringForType);
            
            _userInputController = new UserInputController();
            _userInputController.UserInput.Subscribe(OnUserInputUpdated);
            

            Debug.Log($"Type this string: {_stringForType}");
        }

        private void OnUserInputUpdated(string oldInput, string newInput)
        {
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

        public void Update(float deltaTime)
        {
            if (_isRunning == false)
                return;
            
            _userInputController.Update();
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
            return _userInputValidationService.IsEqual(_userInputController.UserInput.Value);
        }

        private bool DefeatConditionCompleted()
        {
            return _userInputValidationService.IsValid(_userInputController.UserInput.Value) == false;
        }
        
        private string GenerateString()
        {
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();
            GameModesConfig gameModesConfig = configsProviderService.GetConfig<GameModesConfig>();
            
            string symbolsSet = gameModesConfig.SymbolsSets[_inputArgs.SymbolsSetIndex];

            return StringGeneratorService.GenerateString(gameModesConfig.LengthOfStringForType, symbolsSet);
        }

        public void Dispose()
        {
            //
        }
    }
}