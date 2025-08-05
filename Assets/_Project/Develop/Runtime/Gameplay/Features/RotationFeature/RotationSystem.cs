using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using _Project.Develop.Runtime.Utilities.Reactive;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public abstract class RotationSystem: IInitializableSystem, IUpdatableSystem
    {
        private const float RotationThreshold = 0.1f;
        
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<float> _speed;
        
        public abstract Quaternion CurrentRotation { get; }
        
        public virtual void OnInit(Entity entity)
        {
            _direction = entity.RotationDirection;
            _speed = entity.RotationSpeed;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_direction.Value.magnitude < RotationThreshold)
                return;
            
            Quaternion lookRotation = Quaternion.LookRotation(_direction.Value.normalized);
            float step = _speed.Value * deltaTime;
            
            ApplyRotation(Quaternion.RotateTowards(CurrentRotation, lookRotation, step));
        }
        
        protected abstract void ApplyRotation(Quaternion rotation);
    }
}