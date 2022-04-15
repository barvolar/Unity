using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private float _healingPower = 7f;
    private float _damagePower = 10f;

    public float Value { get; private set; }

    private void Start()
    {
        Value = _slider.maxValue; 
    }

    private void Update()
    {
        ControlValue();
    }

    private void ControlValue()
    {
        Value=Mathf.Clamp(Value, 0, _slider.maxValue);
    }

    public void TakeDamage()
    {
        if (Value > 0)
            Value -= _damagePower;
    }

    public void Healing()
    {
        if (Value < _slider.maxValue)
            Value += _healingPower;
    }

    
}
