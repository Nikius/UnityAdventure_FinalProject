using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Energy
{
    public class CurrentEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MaxEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class EnergyRechargeCoefficient : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class EnergyRechargeInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class EnergyRechargeCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class InEnergyRechargeCooldown : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
    
    public class EnergyRechargeCooldownEndEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
}