using System;
using _Project.Develop.Runtime.Configs.Gameplay.Levels;
using _Project.Develop.Runtime.Gameplay.Controllers;
using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;

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
        private GameTaskService _gameTaskService;
        private UserInputService _userInputService;
        
        private bool _isRunning;
        
        public GameMode(DIContainer container, GameplayInputArgs inputArgs)
        {
            _container = container;
            _inputArgs = inputArgs;
        }

        public void Start()
        {
            _isRunning = true;

            _gameTaskService = _container.Resolve<GameTaskService>();
            _gameTaskService.SetTaskString(GenerateString());
            
            _userInputValidationService = new UserInputValidationService(_gameTaskService.TaskString);

            _userInputService = _container.Resolve<UserInputService>();
            _userInputService.InputString.Subscribe(OnUserInputUpdated);

            _userInputController = new UserInputController(_userInputService);
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
            return _userInputValidationService.IsEqual(_userInputService.InputString.Value);
        }

        private bool DefeatConditionCompleted()
        {
            return _userInputValidationService.IsValid(_userInputService.InputString.Value) == false;
        }
        
        private string GenerateString()
        {
            LevelConfig levelConfig = GetLevelConfig();

            return StringGeneratorService.GenerateString(levelConfig.LengthOfStringForType, levelConfig.SymbolsSet);
        }

        private LevelConfig GetLevelConfig()
        {
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();
            LevelsListConfig levelsListConfig = configsProviderService.GetConfig<LevelsListConfig>();
            return levelsListConfig.GetBy(_inputArgs.LevelNumber);
        }

        public void Dispose()
        {
            //
        }
    }
}