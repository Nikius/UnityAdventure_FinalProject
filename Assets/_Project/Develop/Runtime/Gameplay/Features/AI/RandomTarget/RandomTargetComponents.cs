using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.RandomTarget
{
    public class RandomTargetRadius: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class MustGenerateRandomTargetEvent: IEntityComponent
    {
        public ReactiveEvent<ReactiveVariable<Vector3>> Value;
    }
}