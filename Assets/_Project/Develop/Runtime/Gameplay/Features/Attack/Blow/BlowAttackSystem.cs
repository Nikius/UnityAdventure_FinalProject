using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using _Project.Develop.Runtime.Utilities;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.Blow
{
    public class BlowAttackSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _damage;
        private ReactiveEvent _endAttackEvent;
        
        private Buffer<Entity> _contacts;

        private IDisposable _endAttackDisposable;
        
        public void OnInit(Entity entity)
        {
            _damage = entity.BlowDamage;
            _endAttackEvent = entity.EndAttackEvent;
            
            _endAttackDisposable = _endAttackEvent.Subscribe(OnEndAttack);
            
            _contacts = entity.ContactEntitiesBuffer;
        }

        public void OnDispose()
        {
            _endAttackDisposable.Dispose();
        }

        private void OnEndAttack()
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                if (contactEntity.HasComponent<TakeDamageRequest>())
                    contactEntity.TakeDamageRequest.Invoke(_damage.Value);
            }
        }
    }
}