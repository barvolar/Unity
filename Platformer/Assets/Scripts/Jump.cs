using UnityEngine;

namespace Platformer
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] Animator _animator;
        [SerializeField] Rigidbody2D _rigidbody2D;
        [SerializeField] private Player _player;

        private float _power = 910f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J) && _player.IsGroundet)
                _rigidbody2D.AddForce(Vector2.up * _power);
        }
    }
}
