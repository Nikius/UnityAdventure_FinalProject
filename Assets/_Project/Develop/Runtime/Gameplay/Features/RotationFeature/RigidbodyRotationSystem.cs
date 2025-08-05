using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem: RotationSystem
    {
        private Rigidbody _rigidbody;

        public override Quaternion CurrentRotation => _rigidbody.rotation;

        public override void OnInit(Entity entity)
        {
            base.OnInit(entity);
            
            _rigidbody = entity.Rigidbody;
        }

        protected override void ApplyRotation(Quaternion rotation) => _rigidbody.MoveRotation(rotation);
    }
}