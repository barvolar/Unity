using UnityEngine;

namespace HealthUI
{
    public class Health : MonoBehaviour
    {
        private float _powerDamage = 10f;
        private float _powerHealing = 7f;
        private float _maxValueLife = 100f;     
        public float CurrentValueLife { get; private set; }

        private void Update()
        {
            ControlExitBorder();
        }
        public void TakeDamae()
        {
            if (CurrentValueLife > 0)
                CurrentValueLife -= _powerDamage;
        }

        public void Heal()
        {
            if (CurrentValueLife < 100)
                CurrentValueLife += _powerHealing;
        }

        private void ControlExitBorder()
        {
            if (CurrentValueLife < 0)
                CurrentValueLife = 0;

            if (CurrentValueLife > _maxValueLife)
                CurrentValueLife = _maxValueLife;
        }
    }
}
