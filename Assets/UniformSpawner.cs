using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class UniformSpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private SpawnPoint[] _spawnpoints;
    [SerializeField] private float _timePeriod;

    private int _currentSpawnpointIndex = 0;
    private float _lastSpawnTime;

    private SpawnPoint CurrentSpawnPoint => _spawnpoints[_currentSpawnpointIndex];

    private void Update()
    {
        if(Time.time - _lastSpawnTime > _timePeriod)
            Spawn();
    }

    private void Spawn()
    {
        var spawnTransform = CurrentSpawnPoint.transform;
        GameObject.Instantiate(_enemyPrefab, spawnTransform.position, spawnTransform.rotation);

        _lastSpawnTime = Time.time;
        NextSpawnPoint();
    }

    private void NextSpawnPoint()
    {
        _currentSpawnpointIndex = (_currentSpawnpointIndex + 1) % _spawnpoints.Length;
    }
}
