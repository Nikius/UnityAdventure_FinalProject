using System;
using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportEnergySpendSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _energyCost;
        private ReactiveEvent _startTeleportEvent;

        private IDisposable _startTeleportEventDisposable;

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentEnergy;
            _energyCost = entity.TeleportEnergyCost;
            _startTeleportEvent = entity.StartTeleportEvent;

            _startTeleportEventDisposable = _startTeleportEvent.Subscribe(OnTeleportStarted);
        }

        private void OnTeleportStarted()
        {
            _currentEnergy.Value -= _energyCost.Value; 
        }

        public void OnDispose()
        {
            _startTeleportEventDisposable.Dispose();
        }
    }
}