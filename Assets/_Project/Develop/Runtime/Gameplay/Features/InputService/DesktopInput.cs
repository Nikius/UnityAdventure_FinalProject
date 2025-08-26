using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.InputService
{
    public class DesktopInput : IInputService
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        private const string MouseHorizontalAxisName = "Mouse X";
        private const string MouseVerticalAxisName = "Mouse Y";
        private const int LeftMouseButtonCode = 0;

        public bool IsEnabled { get; set; } = true;

        public Vector3 Direction
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));
            }
        }
        
        public Vector3 LookDirection
        {
            get
            {
                if (IsEnabled == false)
                    return Vector3.zero;

                return new Vector3(Input.GetAxisRaw(MouseHorizontalAxisName), 0, Input.GetAxisRaw(MouseVerticalAxisName));
            }
        }
        
        public bool IsAttackButtonDown() => Input.GetMouseButtonDown(LeftMouseButtonCode);
    }
}