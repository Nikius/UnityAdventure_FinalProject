using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class EnergyRechargeSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent _cooldownEndEvent;
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _maxEnergy;
        private ReactiveVariable<float> _rechargeCoefficient;

        private IDisposable _timerDisposable;

        public void OnInit(Entity entity)
        {
            _cooldownEndEvent = entity.EnergyRechargeCooldownEndEvent;
            _currentEnergy = entity.CurrentEnergy;
            _maxEnergy = entity.MaxEnergy;
            _rechargeCoefficient = entity.EnergyRechargeCoefficient;

            _timerDisposable = _cooldownEndEvent.Subscribe(OnCooldownEnded);
        }

        private void OnCooldownEnded()
        {
            if (_currentEnergy.Value < _maxEnergy.Value)
                Recharge();
        }

        private void Recharge()
        {
            _currentEnergy.Value = Mathf.Min(_currentEnergy.Value + _rechargeCoefficient.Value * _maxEnergy.Value, _maxEnergy.Value);
        }

        public void OnDispose()
        {
            _timerDisposable.Dispose();
        }
    }
}