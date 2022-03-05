using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmHandler : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private AudioSource _audioSource;

    private bool _isAlarm;
    private float _maxVolume = 1f;
    private float _minVolume = 0f;
    private float _maxIntensity = 10f;
    private float _minIntensity = 0f;
    private float _maxRange = 10f;
    private float _curentValuem;
    private float _curentIntensity;

    public void OnAlarm()
    {
        _isAlarm = true;
    }

    public void OffAlarm()
    {
        _isAlarm = false;
    }

    private void Start()
    {
        _curentValuem = _audioSource.volume;
        _curentIntensity = _light.intensity;
    }

    private void Update()
    {
        _light.range = Mathf.PingPong(50f*Time.time,_maxRange);
        
        Work();
    }

    private void Work()
    {     
        if (_isAlarm)
        {
            _audioSource.volume = _curentValuem = Mathf.MoveTowards(_curentValuem, _maxVolume, 0.1f * Time.deltaTime);
            _light.intensity = _curentIntensity = Mathf.MoveTowards(_curentIntensity, _maxIntensity, 1f * Time.deltaTime);

        }

        else
        {
            _audioSource.volume = _curentValuem = Mathf.MoveTowards(_curentValuem, _minVolume, 0.1f * Time.deltaTime);
            _light.intensity = _curentIntensity = Mathf.MoveTowards(_curentIntensity, _minIntensity, 1f * Time.deltaTime);
        }
    } 
}
