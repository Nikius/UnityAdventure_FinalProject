﻿using System;

namespace _Project.Develop.Runtime.Infrastructure.DI
{
    public class Registration: IRegistrationOptions
    {
        private readonly Func<DIContainer, object> _creator;
        private object _cachedInstance;

        public bool IsNonLazy { get; private set; }

        public Registration(Func<DIContainer, object> creator)
        {
            _creator = creator;
        }

        public object CreateInstanceFrom(DIContainer container)
        {
            if (_cachedInstance != null)
                return _cachedInstance;
            
            if (_creator == null)
                throw new InvalidOperationException("No creator or instance provided.");
            
            _cachedInstance = _creator.Invoke(container);
            
            return _cachedInstance;
        }

        public void OnInitialize()
        {
            if (_cachedInstance is IInitializable initializable)
                initializable.Initialize();
        }

        public void OnDispose()
        {
            if (_cachedInstance is IDisposable disposable)
                disposable.Dispose();
        }
        
        public void NonLazy() => IsNonLazy = true;
    }
}