using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _power = 10f;
    private float _targetValue = 0;

    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, _power * Time.deltaTime);
    }

    public void TakeDamae()
    {
        if (_targetValue >0)
            _targetValue -= 10f;
    }

    public void Healing()
    {
        if (_targetValue <100)
            _targetValue += 10f;
    }

}
