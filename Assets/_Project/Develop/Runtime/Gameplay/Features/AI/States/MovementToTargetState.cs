using _Project.Develop.Runtime.Gameplay.EntitiesCore;
using _Project.Develop.Runtime.Utilities.Reactive;
using _Project.Develop.Runtime.Utilities.StateMachineCore;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class MovementToTargetState : State, IUpdatableState
    {
        private readonly ReactiveVariable<Vector3> _moveDirection;
        private readonly ReactiveVariable<Vector3> _rotationDirection;
        private readonly ReactiveVariable<Entity> _currentTarget;
        private readonly Transform _transform;

        public MovementToTargetState(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rotationDirection = entity.RotationDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value != null)
            {
                _moveDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;
                _rotationDirection.Value = _moveDirection.Value;
            }
        }
    }
}