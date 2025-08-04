using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public partial class Entity: IDisposable
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new();
        private readonly List<IEntitySystem> _systems = new();
        private readonly List<IInitializableSystem> _initializables = new();
        private readonly List<IUpdatableSystem> _updatables = new();
        private readonly List<IDisposableSystem> _disposables = new();

        private bool _isInit;

        public void Initialize()
        {
            foreach(IInitializableSystem initializable in _initializables)
                initializable.OnInit(this);
            
            _isInit = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isInit == false)
                return;

            foreach (IUpdatableSystem updatable in _updatables)
                updatable.OnUpdate(deltaTime);
        }

        public void Dispose()
        {
            foreach (IDisposableSystem disposable in _disposables)
                disposable.OnDispose();
            
            _isInit = false;
        }

        public Entity AddComponent<TComponent>(TComponent component) where TComponent : class, IEntityComponent
        {
            _components.Add(typeof(TComponent), component);

            return this;
        }

        public bool HasComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            return _components.ContainsKey(typeof(TComponent));
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : class, IEntityComponent
        {
            if (_components.TryGetValue(typeof(TComponent), out IEntityComponent findedObject))
            {
                component = (TComponent)findedObject;
                return true;
            }

            component = null;
            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            if (TryGetComponent(out TComponent component) == false)
                throw new ArgumentException($"Component {typeof(TComponent)} not found.");
            
            return component;
        }

        public Entity AddSystem(IEntitySystem system)
        {
            if (_systems.Contains(system))
                throw new ArgumentException($"System {system.GetType()} already added.");
            
            _systems.Add(system);
            
            if (system is IInitializableSystem initializableSystem)
            {
                _initializables.Add(initializableSystem);
                
                if (_isInit)
                    initializableSystem.OnInit(this);
            }
            
            if (system is IUpdatableSystem updatableSystem)
                _updatables.Add(updatableSystem);
            
            if (system is IDisposableSystem disposableSystem)
                _disposables.Add(disposableSystem);

            return this;
        }
    }
}