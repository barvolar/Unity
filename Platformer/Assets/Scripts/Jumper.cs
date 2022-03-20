using UnityEngine;

namespace Platformer
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] Transform _groundCheckPosition;
        [SerializeField] LayerMask _layerMask;
        [SerializeField] Rigidbody2D _rigidbody2D;

        private float _power = 910f;
        private float _checkRange = 0.2f;

        public bool IsGroundet => CheckIsGround();

        private void Update()
        {
            CheckIsGround();

            if (Input.GetKeyDown(KeyCode.J) && IsGroundet)
                _rigidbody2D.AddForce(Vector2.up * _power);
        }

        private bool CheckIsGround()
        {
            bool isGroundet = Physics2D.OverlapCircle(_groundCheckPosition.position, _checkRange, _layerMask);

            return isGroundet;
        }

    }
}
