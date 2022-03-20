using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] SpriteRenderer _spriteRenderer;
        [SerializeField] Animator _animator;
        [SerializeField] Jumper _jump;

        private float _speed = 7f;
        private float _direction;
        private bool _IsFlip;
        private string _animationNameJump = "isJump";
        private string _animationNameWalk = "isWalk";
        private string _animationNameDeath = "Death";

        private void Start()
        {
            _IsFlip = false;
        }

        private void Update()
        {
            Move();
            FlipHandler();
            Animation();
        }

        private void Move()
        {
            _direction = Input.GetAxisRaw("Horizontal");
            _rigidbody2D.velocity = new Vector2(_direction * _speed, _rigidbody2D.velocity.y);
        }

        private void FlipHandler()
        {
            _IsFlip = _spriteRenderer.flipX;

            if (_direction > 0 && _IsFlip)
                _spriteRenderer.flipX = false;

            if (_direction < 0 && !_IsFlip)
                _spriteRenderer.flipX = true;
        }

        private void Animation()
        {
            if (!_jump.IsGroundet)
                _animator.SetBool(_animationNameJump, true);
            else
                _animator.SetBool(_animationNameJump, false);

            if (_jump.IsGroundet && _direction != 0)
                _animator.SetBool(_animationNameWalk, true);
            else
                _animator.SetBool(_animationNameWalk, false);
        }

        public void StopMove()
        {
            _speed = 0;
            _animator.SetTrigger(_animationNameDeath);
        }
    }
}
