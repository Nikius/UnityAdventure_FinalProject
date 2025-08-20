using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputService
{
    public interface IInputService
    {
        bool IsEnabled { get; set; }
        Vector3 Direction { get; }
    }
}