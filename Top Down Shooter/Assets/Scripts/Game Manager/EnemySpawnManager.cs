using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    public static int EnemyCount;
    
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject[] enemiesToSpawn;
    
    [SerializeField] private int enemiesAmount = 10;
    [SerializeField] private float enemySpawnInterval = 1f;
    [SerializeField] private int waveInterval = 10;

    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private TextMeshProUGUI timeLeftToWaveText;

    private bool _isSpawning;
    
    private float _timeLeftToWave;
    private float _waveNumber = 0;

    private void Start()
    {
        _isSpawning = false;
        
        waveNumberText.text = "Wave number: " + _waveNumber;
        
        _timeLeftToWave = waveInterval;
    }

    private void Update()
    {
        WaveController();
    }

    private void WaveController()
    {
        NextWaveTiming();

        if (Input.GetButtonDown("Jump") || _timeLeftToWave <= 0)
        {
           _waveNumber++;
           waveNumberText.text = "Wave number: " + _waveNumber;
           
           _timeLeftToWave = waveInterval;
           timeLeftToWaveText.gameObject.SetActive(false);

           IncreaseEnemiesAmount();
           
           StartCoroutine(SpawnEnemies());
        }
    }

    private void NextWaveTiming()
    {
        if (!_isSpawning && AreEnemiesDead())
        {
            timeLeftToWaveText.gameObject.SetActive(true);
            _timeLeftToWave -= Time.deltaTime;
            timeLeftToWaveText.text = "Next wave in: " + _timeLeftToWave.ToString("F1");
        }
    }

    private bool AreEnemiesDead()
    {
        if (EnemyCount <= 0)
        {
            return true;
        }

        return false;
    }

    private void IncreaseEnemiesAmount()
    {
        if (_waveNumber >= 2)
        {
            enemiesAmount++;
        }
    }

   private IEnumerator SpawnEnemies()
   {
       int lastSpawnPoint = 0;
       
       _isSpawning = true;
       
       for (int i = 0; i < enemiesAmount; i++)
       {
           int enemyToSpawn = Random.Range(0, enemiesToSpawn.Length);
           
           var spawnPoint = PickSpawnPoint(lastSpawnPoint);
           PoolEnemy(enemyToSpawn, spawnPoint);
           lastSpawnPoint = spawnPoint;
           
           yield return new WaitForSeconds(enemySpawnInterval);
       }
       
       _isSpawning = false;
   } 
   
   private int PickSpawnPoint(int lastSpawnPoint)
   {
       int spawnPoint = Random.Range(0, spawnPoints.Length);

       while (spawnPoint == lastSpawnPoint)
       {
           int newSpawnPoint = Random.Range(0, spawnPoints.Length);
           spawnPoint = newSpawnPoint;
       }

       return spawnPoint;
   }

    private void PoolEnemy(int enemyToSpawn, int spawnPoint)
    {
        var enemy = EnemyPooler.Instance.GetPooledObject(enemiesToSpawn[enemyToSpawn]);

        if (enemy != null)
        {
            enemy.transform.position = spawnPoints[spawnPoint].transform.position;
            enemy.SetActive(true);
            EnemyCount++;
        }
    }
}
