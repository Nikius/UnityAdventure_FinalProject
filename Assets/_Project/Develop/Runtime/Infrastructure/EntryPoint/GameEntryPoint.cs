using System;
using System.Collections;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.ConfigsManagement;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.LoadingScreen;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Infrastructure.EntryPoint
{
    public class GameEntryPoint: MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Project start, setup settings");
            
            SetupAppSettings();
            
            Debug.Log("The process of registering services for the entire project.");
            
            DIContainer projectContainer = new DIContainer();
            
            ProjectContextRegistrations.Process(projectContainer);

            projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
        } 

        private void SetupAppSettings()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            
            loadingScreen.Show();
            
            Debug.Log("Начинается инициализация сервисов");
            
            yield return container.Resolve<ConfigsProviderService>().LoadAsync();

            Debug.Log("Завершается инициализация сервисов");

            loadingScreen.Hide();
            
            yield return sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
        }
    }
}