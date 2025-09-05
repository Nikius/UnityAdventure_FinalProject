using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class SelfDestroyByTriggerState : State, IUpdatableState
    {
        private readonly Entity _entity;
        private readonly ReactiveEvent _event;
        
        private IDisposable _onSelfDestroySubscription;

        public SelfDestroyByTriggerState(Entity entity, ReactiveEvent destroyTrigger)
        {
            _entity = entity;
            _event = destroyTrigger;
        }

        public override void Enter()
        {
            base.Enter();
            
            _onSelfDestroySubscription = _event.Subscribe(OnSelfDestroyTrigger);
        }

        public override void Exit()
        {
            base.Exit();
            
            _onSelfDestroySubscription.Dispose();
        }

        public void Update(float deltaTime)
        {
        }

        private void OnSelfDestroyTrigger()
        {
            _entity.IsDead.Value = true;
        }
    }
}