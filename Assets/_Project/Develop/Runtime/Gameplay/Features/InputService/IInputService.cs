using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputService
{
    public interface IInputService
    {
        bool IsEnabled { get; set; }
        Vector3 Direction { get; }
        public Vector3 LookDirection { get; }

        public bool IsAttackButtonDown();
    }
}