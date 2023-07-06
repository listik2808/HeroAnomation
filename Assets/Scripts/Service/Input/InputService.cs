using UnityEngine;

namespace Scripts.Service.Input
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";
        protected const string ButtonJump = "Jump";

        public abstract Vector2 Axis { get; }

        public bool IsButtonJump() =>
            SimpleInput.GetButton(ButtonJump);

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));
    }
}