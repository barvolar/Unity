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
            if (_slider.value != _health.CurrentValueLife)
                _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentValueLife, _power * Time.deltaTime);
        }
    }
}
