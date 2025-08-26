using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportCooldownTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<bool> _inTeleportCooldown;

        private ReactiveEvent _endTeleportEvent;

        private IDisposable _endTeleportEventDisposable;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.TeleportCooldownCurrentTime;
            _initialTime = entity.TeleportCooldownInitialTime;
            _inTeleportCooldown = entity.InTeleportCooldown;
            _endTeleportEvent = entity.EndTeleportEvent;

            _endTeleportEventDisposable = _endTeleportEvent.Subscribe(OnEndTeleport);
        }

        private void OnEndTeleport()
        {
            Debug.Log("Teleport: КУЛДАУН НАЧАЛСЯ");
            _currentTime.Value = _initialTime.Value;
            _inTeleportCooldown.Value = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inTeleportCooldown.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
            {
                _inTeleportCooldown.Value = false;
                Debug.Log("Teleport: КУЛДАУН ЗАКОНЧИЛСЯ");
            }
        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;

        public void OnDispose()
        {
            _endTeleportEventDisposable.Dispose();
        }
    }
}