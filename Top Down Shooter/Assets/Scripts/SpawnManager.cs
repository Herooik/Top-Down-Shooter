using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemySpawnPoints;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private int _enemiesAmount = 10;
    [SerializeField] private float _spawnInterval = 1f;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        int lastNumberOfSpawnPoint = 0;
        
        for (int i = 0; i < _enemiesAmount; i++)
        {
            int whichEnemyToSpawn = Random.Range(0, _enemies.Length);
            int numberOfSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);

            while (numberOfSpawnPoint == lastNumberOfSpawnPoint)
            {
                int newNumberOfSpawnPoint = Random.Range(0, _enemySpawnPoints.Length);
                numberOfSpawnPoint = newNumberOfSpawnPoint;
            }
            
            Instantiate(_enemies[whichEnemyToSpawn], _enemySpawnPoints[numberOfSpawnPoint].transform.position, Quaternion.identity);

            lastNumberOfSpawnPoint = numberOfSpawnPoint;
            
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
