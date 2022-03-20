using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;      
        [SerializeField] private Movement _movement;

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

        private IEnumerator Death()
        {
            _movement.StopMove();

            yield return new WaitForSeconds(1.5f);

            gameObject.SetActive(false);
        }
    }
}
