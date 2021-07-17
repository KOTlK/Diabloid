using System.Collections;
using UnityEngine;

namespace Game.PlayerInput
{
    public class CameraInput
    {
        public Vector2 Movement { get; private set; }
        public float MouseScrollDelta { get; private set; }
        public bool ShiftHolding { get; private set; }


        public void UpdateInput()
        {
            Movement = UpdateMovement();
            MouseScrollDelta = ReadMouseWheel();
            ShiftHolding = ReadShiftButton();
        }
        private Vector3 UpdateMovement()
        {
            Vector2 temp;
            temp.x = Input.GetAxisRaw("Horizontal");
            temp.y = Input.GetAxisRaw("Vertical");
            return temp;
        }

        private float ReadMouseWheel()
        {
            return Input.GetAxisRaw("Mouse ScrollWheel");
        }

        private bool ReadShiftButton()
        {
            return Input.GetKey(KeyCode.LeftShift);
        }
    }
}