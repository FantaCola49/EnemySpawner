using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _allSpawnDots;
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawnPoint;
    private float _spawnBrake = 2f;

    void Start()
    {
        _spawnPoint = new Transform[_allSpawnDots.childCount];

        for(int i = 0; i < _allSpawnDots.childCount; i++)
        {
            _spawnPoint[i] = _allSpawnDots.GetChild(i); 
        }

        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn()
    {
        for (int SpawnIndex = 0; SpawnIndex < _spawnPoint.Length; SpawnIndex++)
        {
            Instantiate(_enemy, _spawnPoint[SpawnIndex].position, Quaternion.identity);
            Debug.Log("Сгенерирован враг");
            yield return new WaitForSeconds(_spawnBrake);
        }
        StartCoroutine(EnemySpawn());
    }
}
