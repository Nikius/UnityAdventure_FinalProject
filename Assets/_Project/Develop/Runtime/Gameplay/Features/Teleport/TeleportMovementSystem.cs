using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportMovementSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<Vector3> _targetPosition;
        private Transform _transform;

        private ReactiveEvent _endTeleportEvent;

        private IDisposable _endTeleportEventDisposable;

        public void OnInit(Entity entity)
        {
            _targetPosition = entity.TeleportTarget;
            _transform = entity.Transform;
            _endTeleportEvent = entity.EndTeleportEvent;

            _endTeleportEventDisposable = _endTeleportEvent.Subscribe(OnTeleportEnded);
        }

        private void OnTeleportEnded()
        {
            _transform.position = _targetPosition.Value;
        }

        public void OnDispose()
        {
            _endTeleportEventDisposable.Dispose();
        }
    }
}