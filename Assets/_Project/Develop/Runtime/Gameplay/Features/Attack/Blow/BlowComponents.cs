using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Gameplay.Features.Attack.Blow
{
    public class BlowRadius: IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    
    public class BlowDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
}