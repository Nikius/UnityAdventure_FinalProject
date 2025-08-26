using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Conditions;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.Teleport
{
    public class TeleportRadius: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class TeleportTarget: IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }
    
    public class TeleportEnergyCost: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class CanStartTeleport : IEntityComponent
    {
        public ICompositeCondition Value;
    }
    
    public class StartTeleportRequest : IEntityComponent
    {
        public ReactiveEvent Value;
    }
    
    public class StartTeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
    
    public class EndTeleportEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
    
    public class TeleportProcessInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class TeleportProcessCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class InTeleportProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
    
    public class TeleportDelayTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportDelayEndEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
    
    public class TeleportCooldownInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportCooldownCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class InTeleportCooldown : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}