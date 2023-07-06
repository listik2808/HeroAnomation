using Assets.Scripts;
using CodeBase.CameraLogic;
using Scripts.Service.Input;
using UnityEngine;

namespace Scripts.Hero
{
    [RequireComponent(typeof(CharacterController))]
    public class Move : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Camera _camera;

        private CharacterController _characterController;
        private IInputService _inputService;
        private AnimatorHero _hero;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _hero = GetComponent<AnimatorHero>();
            _inputService = Game.InputService;
            _camera.GetComponent<CameraFollow>().Follow(gameObject);
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Constant.Epsilon)
            {
                _hero.PlayRun();
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            else
            {
                _hero.PlayIdle();
            }

            _characterController.Move(_speed * movementVector * Time.deltaTime);
        }
    }
}