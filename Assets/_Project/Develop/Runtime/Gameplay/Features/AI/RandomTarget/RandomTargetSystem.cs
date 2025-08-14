using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.RandomTarget
{
    public class RandomTargetSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _radius;
        private ReactiveEvent<ReactiveVariable<Vector3>> _mustGenerateEvent;

        private IDisposable _mustGenerateEventDisposable;
        
        public void OnInit(Entity entity)
        {
            _radius = entity.RandomTargetRadius;
            _mustGenerateEvent = entity.MustGenerateRandomTargetEvent;

            _mustGenerateEventDisposable = _mustGenerateEvent.Subscribe(OnMustGenerateEvent);
        }

        private void OnMustGenerateEvent(ReactiveVariable<Vector3> position)
        {
            position.Value = new Vector3(
                Random.Range(-_radius.Value, _radius.Value),
                0,
                Random.Range(-_radius.Value, _radius.Value)
            );
        }

        public void OnDispose()
        {
            _mustGenerateEventDisposable.Dispose();
        }
    }
}