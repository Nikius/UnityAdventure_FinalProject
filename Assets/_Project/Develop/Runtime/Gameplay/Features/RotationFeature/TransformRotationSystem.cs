using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class TransformRotationSystem: RotationSystem
    {
        private Transform _transform;

        public override Quaternion CurrentRotation => _transform.rotation;

        public override void OnInit(Entity entity)
        {
            base.OnInit(entity);
            
            _transform = entity.Transform;
        }

        protected override void ApplyRotation(Quaternion rotation) => _transform.rotation = rotation;
    }
}