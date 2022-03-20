using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheckPosition;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Animator _animator;       
        [SerializeField] private Movement _movement;

        private float _checkRange = 0.2f;

        public bool IsGroundet { get; private set; }

        private void Update()
        {
            CheckIsGround();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Cherry>(out Cherry cherry))
            {
                Destroy(collision.gameObject);              
                _audioSource.Play();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                StartCoroutine(Death());
        }

        private void CheckIsGround()
        {
            IsGroundet = Physics2D.OverlapCircle(_groundCheckPosition.position, _checkRange, _layerMask);
        }

        private IEnumerator Death()
        {
            _movement.StopMove();

            yield return new WaitForSeconds(1.5f);

            gameObject.SetActive(false);
        }
    }
}
