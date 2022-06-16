using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : Pool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGameObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPoint = Random.Range(0, _spawnPoints.Length);
                int randomEnemy = Random.Range(0, _enemyPrefab.Length);
                
                SetEnemy(enemy, _spawnPoints[spawnPoint].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
