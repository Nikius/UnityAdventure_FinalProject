using System;
using System.Collections;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Infrastructure
{
    public class GameplayBootstrap: SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;
        private GameplayCycle _gameplayCycle;
        
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
            Debug.Log($"Current level: {_inputArgs.SymbolsSetIndex}");
            
            _gameplayCycle = new GameplayCycle(_container, _inputArgs);
            
            yield return _gameplayCycle.Prepare();
        }

        public override void Run() => _gameplayCycle.Launch();
        
        private void Update() => _gameplayCycle?.Update(Time.deltaTime);
        
        private void OnDestroy() => Dispose();
        public override void Dispose() => _gameplayCycle?.Dispose();
    }
}