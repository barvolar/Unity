using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
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
        int spawnBoxIndex = 0;

        for (int i = 0; i < _spawnCount; i++)
        {
            if (spawnBoxIndex >= _spawnBoxes.Length)
                spawnBoxIndex = 0;

            SpawnBall(_spawnBoxes[spawnBoxIndex].transform);
            spawnBoxIndex++;

            yield return _waitForSeconds;
        }
    }

    private void SpawnBall(Transform position)
    {
        Instantiate(_prefab, position.position, Quaternion.identity);
    }
}
