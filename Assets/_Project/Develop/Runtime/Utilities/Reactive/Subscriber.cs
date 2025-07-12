﻿using System;

namespace _Project.Develop.Runtime.Utilities.Reactive
{
    public class Subscriber<T, K>: IDisposable
    {
        private readonly Action<T, K> _action;
        private readonly Action<Subscriber<T, K>> _onDispose;

        public Subscriber(Action<T, K> action, Action<Subscriber<T, K>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }
        
        public void Invoke(T arg1, K arg2) => _action?.Invoke(arg1, arg2);
        
        public void Dispose() => _onDispose?.Invoke(this);
    }
}