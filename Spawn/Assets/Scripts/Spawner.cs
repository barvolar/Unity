using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    [SerializeField] private Ball _prefab;
    [SerializeField] private SpawnBox[] _spawnBoxes;

    private WaitForSeconds _waitForSeconds;
    private float _spawnCount = 100f;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(2);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int index = 0;

        for (int i = 0; i < _spawnCount; i++)
        {
            if (index >= _spawnBoxes.Length)
                index = 0;

            SpawnBall(_spawnBoxes[index].transform);
            index++;

            yield return _waitForSeconds;
        }
    }

    private void SpawnBall(Transform position)
    {
        Instantiate(_prefab, position.position, Quaternion.identity);
    }
}
