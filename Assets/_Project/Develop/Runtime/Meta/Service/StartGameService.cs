using _Project.Develop.Runtime.Gameplay.Infrastructure;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;

namespace _Project.Develop.Runtime.Meta.Service
{
    public static class StartGameService
    {
        public static void StartGame(DIContainer container, int symbolsSetIndex)
        {
            SceneSwitcherService sceneSwitcherService = container.Resolve<SceneSwitcherService>();
            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
            coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(symbolsSetIndex)));
        }
    }
}