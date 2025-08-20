using System;

namespace _Project.Develop.Runtime.Utilities.Reactive
{
    public interface IReadOnlyEvent
    {
        IDisposable Subscribe(Action action);
    }
    
    public interface IReadonlyEvent<T>
    {
        IDisposable Subscribe(Action<T> action);
    }
}