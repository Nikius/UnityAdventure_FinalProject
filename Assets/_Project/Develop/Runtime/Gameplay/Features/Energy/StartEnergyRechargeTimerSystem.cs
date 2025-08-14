using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class StartEnergyRechargeTimerSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<bool> _inCooldown;
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _maxEnergy;

        private IDisposable _currentEnergyChangedDisposable;

        public void OnInit(Entity entity)
        {
            _inCooldown = entity.InEnergyRechargeCooldown;
            _currentEnergy = entity.CurrentEnergy;
            _maxEnergy = entity.MaxEnergy;

            _currentEnergyChangedDisposable = _currentEnergy.Subscribe(OnCurrentEnergyChanged);
        }

        private void OnCurrentEnergyChanged(float arg1, float currentEnergy)
        {
            Debug.Log("Current Energy: " + _currentEnergy.Value);
            
            if (_inCooldown.Value)
                return;
            
            if (_currentEnergy.Value < _maxEnergy.Value)
                StartRechargeCooldown();
        }

        public void OnDispose()
        {
            _currentEnergyChangedDisposable.Dispose();
        }
        
        private void StartRechargeCooldown()
        {
            _inCooldown.Value = true;
        }
    }
}