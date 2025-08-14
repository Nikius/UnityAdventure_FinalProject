using _Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore.Common
{
    public class TransformEntityRegistrator: MonoEntityRegistrator
    {
        public override void Register(Entity entity)
        {
            entity.AddTransform(GetComponent<Transform>());
        }
    }
}