using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private GameObject _spawnBox1;
    [SerializeField] private GameObject _spawnBox2;
    [SerializeField] private GameObject _spawnObject;

    private float _spawnCount = 100f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            CreateBall(_spawnBox1.transform);
            Debug.Log(Time.time);

            yield return new WaitForSeconds(2);

            CreateBall(_spawnBox2.transform);
            Debug.Log(Time.time);

            yield return new WaitForSeconds(2);
        }
    }

    private void CreateBall(Transform position)
    {
        Instantiate(_spawnObject, position.position, Quaternion.identity);
    }
}
