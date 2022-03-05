using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject[] _spawnBoxes;

    private float _spawnCount = 100f;

    private void Start()
    {

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int spawnBoxIndex = 0;

        for (int i = 0; i < _spawnCount; i++)
        {
            if (spawnBoxIndex >= _spawnBoxes.Length)
                spawnBoxIndex = 0;

            CreateBall(_spawnBoxes[spawnBoxIndex].transform);
            spawnBoxIndex++;

            yield return new WaitForSeconds(1);
        }
    }

    private void CreateBall(Transform position)
    {
        Instantiate(_prefab, position.position, Quaternion.identity);
    }
}
