using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;
    [SerializeField] Transform _GroundCheckPosition;
    [SerializeField] LayerMask _layerMask;

    private float _speed = 7f;
    private float _direction;
    private float _checkRange = 0.2f;
    private float _jumpPower = 1100f;
    private bool _isGroundet;
    private bool _IsFlip;


    private void Start()
    {
        _IsFlip = false;
    }

    private void Update()
    {
        Move();
        FlipHandler();
        MoveAnimations();
        Jump();
        CheckIsGround();
        Debug.Log(_isGroundet);
    }
    
    private void Move()
    {
        _direction = Input.GetAxisRaw("Horizontal");
        _rigidbody2D.velocity = new Vector2(_direction * _speed, _rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.J)&&_isGroundet)
            _rigidbody2D.AddForce(Vector2.up * _jumpPower);
    }

    private void CheckIsGround()
    {
        _isGroundet = Physics2D.OverlapCircle(_GroundCheckPosition.position, _checkRange, _layerMask);
    }

    private void FlipHandler()
    {
        _IsFlip=_spriteRenderer.flipX;
        if (_direction > 0 && _IsFlip)
            _spriteRenderer.flipX = false;
        if (_direction < 0 && !_IsFlip)
            _spriteRenderer.flipX = true;
    }

    private void MoveAnimations()//переименовать
    {
        if (!_isGroundet)
            _animator.SetTrigger("Jump");
        if (_isGroundet && _direction !=0)
            _animator.SetBool("isWalk", true);
        else
            _animator.SetBool("isWalk", false);
    }
}
