using UnityEngine;

namespace Platformer
{
    public class Jump : MonoBehaviour
    {
        [SerializeField] Transform _groundCheckPosition;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] Rigidbody2D _rigidbody2D;

        private float _power = 910f;
        private float _checkRange = 0.2f;

        public bool IsGroundet { get; private set; }

        private void Update()
        {
            CheckIsGround();

            if (Input.GetKeyDown(KeyCode.J) && IsGroundet)
                _rigidbody2D.AddForce(Vector2.up * _power);
        }

        private void CheckIsGround()
        {
            IsGroundet = Physics2D.OverlapCircle(_groundCheckPosition.position, _checkRange, _layerMask);
        }
    }
}
