using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class AttackByTriggerSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly ReactiveEvent _attackEvent;
        
        private ReactiveEvent _startAttackRequest;
        
        private IDisposable _attackEventDisposable;

        public AttackByTriggerSystem(ReactiveEvent attackEvent)
        {
            _attackEvent = attackEvent;
        }

        public void OnInit(Entity entity)
        {
            _startAttackRequest = entity.StartAttackRequest;
            _attackEventDisposable = _attackEvent.Subscribe(OnAttackEvent);
        }

        private void OnAttackEvent()
        {
            _startAttackRequest.Invoke();
        }

        public void OnDispose()
        {
            _attackEventDisposable.Dispose();
        }
    }
}