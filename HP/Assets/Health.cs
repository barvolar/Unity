using UnityEngine;

namespace HealthUI
{
    public class Health : MonoBehaviour
    {
        public float TargetValue { get; private set; }

        public void TakeDamae()
        {
            if (TargetValue > 0)
                TargetValue -= 10f;
        }

        public void Healing()
        {
            if (TargetValue < 100)
                TargetValue += 10f;
        }
    }
}
