using System;
using System.Collections;
using _Project.Develop.Runtime.Configs;
using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Infrastructure
{
    public class MainMenuBootstrap: SceneBootstrap
    {
        private DIContainer _container;
        private MainMenuCycle _mainMenuCycle;
        
        private bool _isRunning;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;
            
            MainMenuContextRegistrations.Process(_container);
        }

        public override IEnumerator Initialize()
        {
            Debug.Log("MainMenuBootstrap initialized");
            
            _mainMenuCycle = new MainMenuCycle(_container);
            
            yield return _mainMenuCycle.Prepare();
        }

        public override void Run()
        {
            _mainMenuCycle.Launch();

            _isRunning = true;
        }

        private void Update()
        {
            if (_isRunning == false)
                return;
            
            _mainMenuCycle.Update(Time.deltaTime);
        }
        
        private void OnDestroy() => _mainMenuCycle?.Dispose();
    }
}