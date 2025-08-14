using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class StartTeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _startTeleportRequest;
        private ReactiveEvent _startTeleportEvent;
        private ReactiveVariable<bool> _inTeleportProcess;
        private ICompositeCondition _canStartTeleport;

        private IDisposable _teleportRequestDispose;

        public void OnInit(Entity entity)
        {
            _startTeleportRequest = entity.StartTeleportRequest;
            _startTeleportEvent = entity.StartTeleportEvent;
            _inTeleportProcess = entity.InTeleportProcess;
            _canStartTeleport = entity.CanStartTeleport;

            _teleportRequestDispose = _startTeleportRequest.Subscribe(OnTeleportRequest);
        }

        private void OnTeleportRequest()
        {
            if (_canStartTeleport.Evaluate())
            {
                _inTeleportProcess.Value = true;
                _startTeleportEvent.Invoke();
                Debug.Log("Teleportation started");
            }
            else
            {
                Debug.Log("Can't teleport");
            }
        }

        public void OnDispose()
        {
            _teleportRequestDispose.Dispose();
        }
    }
}