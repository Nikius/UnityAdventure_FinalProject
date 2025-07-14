using _Project.Develop.Runtime.Common.Controllers;
using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.SceneManagement;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Controllers
{
    public class RestartController: Controller
    {
        public RestartController(DIContainer container) : base(container)
        {
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneSwitcherService sceneSwitcherService = Container.Resolve<SceneSwitcherService>();
                ICoroutinesPerformer coroutinesPerformer = Container.Resolve<ICoroutinesPerformer>();
                coroutinesPerformer.StartPerform(sceneSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            }
        }
    }
}