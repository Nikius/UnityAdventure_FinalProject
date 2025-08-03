using _Project.Develop.Runtime.Gameplay.Services;
using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.UI.Gameplay
{
    public class GameplayPresenterFactory
    {
        private readonly DIContainer _container;

        public GameplayPresenterFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresenter CreateGameplayScreen(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<GameTaskService>(),
                _container.Resolve<UserInputService>()
            );
        }
    }
}