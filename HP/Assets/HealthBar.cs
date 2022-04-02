using UnityEngine;
using UnityEngine.UI;

namespace HealthUI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Health _health;

        private float _power = 10f;

        private void Update()
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _health.TargetValue, _power * Time.deltaTime);
        }      
    }
}
