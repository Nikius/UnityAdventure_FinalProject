using System;
using System.Collections.Generic;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class TeleportationState : State, IUpdatableState
    {
        private Entity _entity;
        private ITargetSelector _targetSelector;
        private EntitiesLifeContext _entitiesLifeContext;

        private IDisposable _teleportTargetDisposable;

        public TeleportationState(Entity entity, ITargetSelector targetSelector, EntitiesLifeContext entitiesLifeContext)
        {
            _entity = entity;
            _targetSelector = targetSelector;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("TeleportationState Enter");

            _teleportTargetDisposable = _entity.TeleportTarget.Subscribe(OnTeleportTargetChanged);
            
            Entity target = _targetSelector.SelectTargetFrom(_entitiesLifeContext.Entities);
            
            if (target != null)
                _entity.TeleportTarget.Value = target.Transform.position;
            else
                _entity.MustGenerateRandomTargetEvent.Invoke(_entity.TeleportTarget);
        }

        public override void Exit()
        {
            base.Exit();
            Debug.Log("TeleportationState Exit");
            
            _teleportTargetDisposable.Dispose();
        }

        private void OnTeleportTargetChanged(Vector3 arg1, Vector3 arg2)
        {
            _entity.StartTeleportRequest.Invoke();
        }

        public void Update(float deltaTime)
        {
        }
    }
}