using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UniformSpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _timePeriod;

    private int _currentSpawnpointIndex = 0;
    private Coroutine _spawnProcess;

    private SpawnPoint CurrentSpawnPoint => _spawnpoints[_currentSpawnpointIndex];

    private void Start()
    {
        _spawnProcess = StartCoroutine(SpawnProcess());
    }

    private IEnumerator SpawnProcess()
    {
        var timePeriod = new WaitForSeconds(_timePeriod);

        while(true)
        {
            yield return timePeriod;
            Spawn();
        }
    }

    private void Spawn()
    {
        var spawnTransform = CurrentSpawnPoint.transform;
        GameObject.Instantiate(_enemyPrefab, spawnTransform.position, spawnTransform.rotation);
        NextSpawnPoint();
    }

    private void NextSpawnPoint()
    {
        _currentSpawnpointIndex = (_currentSpawnpointIndex + 1) % _spawnpoints.Length;
    }
}
