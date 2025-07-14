using _Project.Develop.Runtime.Infrastructure.DI;

namespace _Project.Develop.Runtime.Common.Controllers
{
    public abstract class Controller 
    {
        private bool _isEnabled;
        
        protected readonly DIContainer Container;

        protected Controller(DIContainer container)
        {
            Container = container;
        }

        public virtual void Enable() => _isEnabled = true;
        public virtual void Disable() => _isEnabled = false;

        public void Update(float deltaTime)
        {
            if (_isEnabled == false)
                return;

            UpdateLogic(deltaTime);
        }

        protected abstract void UpdateLogic(float deltaTime);
    }
}
