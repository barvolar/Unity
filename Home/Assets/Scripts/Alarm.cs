using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private AudioSource _audioSource;

    private bool _isIntrusion;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _maxIntensity = 10f;
    private float _minIntensity = 0f;
    private float _maxRange = 10f;
    private float _flashSpeed = 50f;

    public void TurnOn()
    {
        _isIntrusion = true;
    }

    public void TurnOff()
    {
        _isIntrusion = false;
    }

    private void Update()
    {
        _light.range = Mathf.Repeat(_flashSpeed * Time.time, _maxRange);
        Work();
    }

    private void Work()
    {
        if (_isIntrusion && _audioSource.volume < _maxVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, 0.1f * Time.deltaTime);
            _light.intensity = Mathf.MoveTowards(_light.intensity, _maxIntensity, 1f * Time.deltaTime);
        }

        else if (!_isIntrusion && _audioSource.volume > _minVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, 0.1f * Time.deltaTime);
            _light.intensity = Mathf.MoveTowards(_light.intensity, _minIntensity, 1f * Time.deltaTime);         
        }
    }
}
