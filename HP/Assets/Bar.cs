using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
 
    private float _speed = 0.5f;
   
    private void Update()
    {     
        if(_health.Value!=_slider.value)
            StartCoroutine(EditBarValue());

        else
            StopCoroutine(EditBarValue());
    }

    private IEnumerator EditBarValue()
    {
        while(_health.Value != _slider.value)
        {
            _slider.value = Mathf.MoveTowards(_slider.value,_health.Value, _speed*Time.deltaTime);
            Debug.Log(_slider.value);

            yield return null;
        }
    }
}
