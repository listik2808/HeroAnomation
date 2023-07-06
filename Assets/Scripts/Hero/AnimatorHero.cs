using Scripts;
using System;
using UnityEngine;

namespace Scripts.Hero
{
    public class AnimatorHero : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _left;
        [SerializeField] private ParticleSystem _right;

        private bool _isMove = false;
        private bool _isGround = true;

        public const string RunHero = "RunBull";
        public const string JumpHero = "Jump";
        public const string IdleHero = "Idle";
        public const string IsAttack = "IsAttack";
        public const string AttackRun = "AttackRun";

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ground ground))
            {
                _isGround = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Ground ground))
            {
                _isGround = false;
            }
        }

        public void SetMove(bool value)
        {
            _isMove = value;
        }

        public void PlayAttack()
        {
            if (_isMove == false)
            {
                _animator.SetTrigger(IsAttack);
            }
        }

        public void PlayAttackRun()
        {
            if (_isMove)
            {
                _animator.SetTrigger(AttackRun);
            }
        }

        public void PlayRun()
        {
            SetMove(true);
            _animator.SetBool(IdleHero, false);
            _animator.SetBool(RunHero, true);
        }

        public void PlayIdle()
        {
            SetMove(false);
            _animator.SetBool(RunHero, false);
            _animator.SetBool(IdleHero, true);
        }

        public void PlayJump()
        {
            if (_isGround)
            {
                SetMove(false);
                _animator.SetTrigger(JumpHero);

            }
        }

        public void PlayeTracesLeft()
        {
            _left.Play();
        }

        public void PlayeTracesRight()
        {
            _right.Play();
        }
    }
}