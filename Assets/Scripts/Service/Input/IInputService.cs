using UnityEngine;

namespace Scripts.Service.Input
{
    public interface IInputService
    {
        Vector2 Axis { get; }
        bool IsButtonJump();
    }
}