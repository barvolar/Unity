using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmField : MonoBehaviour
{
    [SerializeField] private UnityEvent _intrusion;
    [SerializeField] private UnityEvent _escape;
   
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _intrusion!.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _escape!.Invoke();
        }
    }
}
