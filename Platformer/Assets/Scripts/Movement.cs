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
        [SerializeField] Jump _jump;

        private float _speed = 7f;
        private float _direction;     
        private bool _IsFlip;
       
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
                _animator.SetBool("isJump", true);
            else
                _animator.SetBool("isJump", false);

            if (_jump.IsGroundet && _direction != 0)
                _animator.SetBool("isWalk", true);
            else
                _animator.SetBool("isWalk", false);
        }

        public void StopMove()
        {
            _speed = 0;
            _animator.SetTrigger("Death");
        }
    }
}
