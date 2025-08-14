using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class EnergyRechargeTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<bool> _inCooldown;
        private ReactiveEvent _cooldownEndEvent;
        
        private IDisposable _inCooldownChangedDisposable;

        public void OnInit(Entity entity)
        {
            _currentTime = entity.EnergyRechargeCurrentTime;
            _initialTime = entity.EnergyRechargeInitialTime;
            _inCooldown = entity.InEnergyRechargeCooldown;
            _cooldownEndEvent = entity.EnergyRechargeCooldownEndEvent;
            
            _inCooldownChangedDisposable = _inCooldown.Subscribe(OnInCooldownChanged);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inCooldown.Value && TimeIsDone(_currentTime.Value))
            {
                _inCooldown.Value = false;
                _currentTime.Value = 0;
                _cooldownEndEvent.Invoke();

                return;
            }

            _currentTime.Value += deltaTime;
        }

        private void OnInCooldownChanged(bool arg1, bool inCooldown)
        {
            if (inCooldown)
                _currentTime.Value = 0;
        }

        private bool TimeIsDone(float currentTime) => currentTime >= _initialTime.Value;
        
        public void OnDispose()
        {
            _inCooldownChangedDisposable.Dispose();
        }
    }
}