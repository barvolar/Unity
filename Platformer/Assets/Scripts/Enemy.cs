using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] SpriteRenderer _spriteRenderer;

        private int _directionIndex;
        private float _speed = 5f;

        private void Start()
        {
            _directionIndex = 1;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<LeftWall>(out LeftWall left))
            {
                _directionIndex = 1;
                _spriteRenderer.flipX = true;
            }
            if (collision.TryGetComponent<RightWall>(out RightWall right))
            {
                _directionIndex = -1;
                _spriteRenderer.flipX = false;
            }
        }
     
        private void Move()
        {
            _rigidbody2D.velocity = new Vector2(_directionIndex * _speed, _rigidbody2D.velocity.y);
        }       
    }
}
