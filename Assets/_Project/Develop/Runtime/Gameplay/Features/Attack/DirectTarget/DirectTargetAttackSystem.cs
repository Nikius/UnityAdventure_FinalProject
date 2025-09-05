using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.DirectTarget
{
    public class DirectTargetAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private readonly ReactiveVariable<float> _damage;
        
        private Entity _entity;
        private ReactiveEvent _endAttackEvent;
        
        private IDisposable _endAttackDisposable;

        public DirectTargetAttackSystem(ReactiveVariable<float> damage)
        {
            _damage = damage;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _endAttackEvent = _entity.EndAttackEvent;
            
            _endAttackDisposable = _endAttackEvent.Subscribe(OnEndAttack);
        }

        private void OnEndAttack()
        {
            _entity.CurrentTarget.Value.TakeDamageRequest.Invoke(_damage.Value);
        }

        public void OnDispose()
        {
            _endAttackDisposable.Dispose();
        }
    }
}