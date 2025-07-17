using _Project.Develop.Runtime.Common.Controllers;
using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Infrastructure.DI;
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
                RestartGameService.RestartGame(Container);
        }
    }
}