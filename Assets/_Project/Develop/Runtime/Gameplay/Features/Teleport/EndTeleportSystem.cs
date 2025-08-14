using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class EndTeleportSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _endTeleportEvent;
        private ReactiveVariable<bool> _inTeleportProcess;
        private ReactiveVariable<float> _teleportProcessInitialTime;
        private ReactiveVariable<float> _teleportProcessCurrentTime;

        private IDisposable _timerDisposable;

        public void OnInit(Entity entity)
        {
            _endTeleportEvent = entity.EndTeleportEvent;
            _inTeleportProcess = entity.InTeleportProcess;
            _teleportProcessInitialTime = entity.TeleportProcessInitialTime;
            _teleportProcessCurrentTime = entity.TeleportProcessCurrentTime;

            _timerDisposable = _teleportProcessCurrentTime.Subscribe(OnTimerChanged);
        }

        private void OnTimerChanged(float arg1, float currentTime)
        {
            if (TimeIsDone(currentTime))
            {
                Debug.Log("Teleport ended");
                _inTeleportProcess.Value = false;
                _endTeleportEvent.Invoke();
            }
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }

        private bool TimeIsDone(float currentTime) => currentTime >= _teleportProcessInitialTime.Value;
    }
}