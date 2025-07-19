using _Project.Develop.Runtime.Infrastructure.DI;
using _Project.Develop.Runtime.Utilities.CoroutinesManagement;
using _Project.Develop.Runtime.Utilities.DataManagement.DataProviders;

namespace _Project.Develop.Runtime.Utilities.DataManagement
{
    public class AutosaveService
    {
        private readonly DIContainer _container;

        public AutosaveService(DIContainer container)
        {
            _container = container;
        }

        public void Run()
        {
            PlayerDataProvider playerDataProvider = _container.Resolve<PlayerDataProvider>();
            ICoroutinesPerformer coroutinesPerformer = _container.Resolve<ICoroutinesPerformer>();
            coroutinesPerformer.StartPerform(playerDataProvider.Save());
        }
    }
}