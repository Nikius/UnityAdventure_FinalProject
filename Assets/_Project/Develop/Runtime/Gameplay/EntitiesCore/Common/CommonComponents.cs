using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.EntitiesCore.Common
{
    public class RigidbodyComponent : IEntityComponent
    {
        public Rigidbody Value;
    }
    
    public class TransformComponent : IEntityComponent
    {
        public Transform Value;
    }

    public class IDComponent : IEntityComponent
    {
        public string Value;
    }
}