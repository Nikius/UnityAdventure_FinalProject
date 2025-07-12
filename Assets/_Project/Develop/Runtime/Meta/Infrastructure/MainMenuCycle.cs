using System;
using System.Collections;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuCycle: IDisposable
    {
        private const int KeyCodeAlpha1 = (int)KeyCode.Alpha1;
        
        private readonly DIContainer _container;
        private GameModesConfig _gameModesConfig;

        public MainMenuCycle(DIContainer container)
        {
            _container = container;
        }

        public IEnumerator Prepare()
        {
            ConfigsProviderService configsProviderService = _container.Resolve<ConfigsProviderService>();
            _gameModesConfig = configsProviderService.GetConfig<GameModesConfig>();
            
            ConfigsValidation();
            
            yield return null;
        }

        public void Launch()
        {
            Debug.Log("Choose one of the following symbols set for game: ");
            
            for (int i = 0; i < _gameModesConfig.SymbolsSets.Count; i++)
                Debug.Log($"{i+1}. {_gameModesConfig.SymbolsSets[i]}");
        }

        public void Update(float deltaTime)
        {
            if (Input.anyKeyDown)
                for (int i = KeyCodeAlpha1; i < KeyCodeAlpha1 + _gameModesConfig.SymbolsSets.Count; i++)
                    if (Input.GetKeyDown((KeyCode)i))
                        StartGame(i - KeyCodeAlpha1);
        }
        
        private void ConfigsValidation()
        {
            if (_gameModesConfig.SymbolsSets.Count == 0)
                throw new ApplicationException("Symbols set count should be more than zero");
            if (_gameModesConfig.SymbolsSets.Count > 9)
                throw new ApplicationException("Symbols set count should be less than nine");
            if (_gameModesConfig.LengthOfStringForType <= 0)
                throw new ApplicationException("Length Of String For Type should be greater than zero");
        }
        
        private void StartGame(int symbolsSetIndex)
        {
            SceneSwitcherService sceneSwitcherService = _container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(symbolsSetIndex)));
        }

        public void Dispose()
        {
            //
        }
    }
}