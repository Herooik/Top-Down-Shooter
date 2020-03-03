using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnPoints;
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private int _enemiesAmount = 10;

    [SerializeField] private float _spawnInterval = 1f;
    [SerializeField] private float _waveInterval = 10f;

    [SerializeField] private TextMeshProUGUI _waveNumberText;
    [SerializeField] private TextMeshProUGUI _timeLeftToWaveText;

    private bool _isSpawning;
    
    private float _timeLeftToWave;
    private float _waveNumber = 0;

    [HideInInspector] public int _count;

    private void Start()
    {
        _isSpawning = false;
        
        _waveNumberText.text = "Wave number: " + _waveNumber;
        
        _timeLeftToWave = _waveInterval;
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
            _waveNumberText.text = "Wave number: " + _waveNumber;
            
            _timeLeftToWave = _waveInterval;
            _timeLeftToWaveText.gameObject.SetActive(false);

            StartCoroutine(SpawnEnemies());
        }
    }

    private void NextWaveTiming()
    {
        if (!_isSpawning && AreEnemiesDead())
        {
            _timeLeftToWaveText.gameObject.SetActive(true);
            _timeLeftToWave -= Time.deltaTime;
           _timeLeftToWaveText.text = "Next wave in: " + _timeLeftToWave.ToString("F1");
        }
    }

    private IEnumerator SpawnEnemies()
    {
        int lastSpawnPoint = 0;
        
        _isSpawning = true;
        
        for (int i = 0; i < _enemiesAmount; i++)
        {
            int enemyToSpawn = Random.Range(0, _enemies.Length);
            int spawnPoint = Random.Range(0, _spawnPoints.Length);

            while (spawnPoint == lastSpawnPoint)
            {
                int newSpawnPoint = Random.Range(0, _spawnPoints.Length);
                spawnPoint = newSpawnPoint;
            }
            
            Instantiate(_enemies[enemyToSpawn], _spawnPoints[spawnPoint].transform.position, Quaternion.identity);
            
            lastSpawnPoint = spawnPoint;
            
            yield return new WaitForSeconds(_spawnInterval);

            _count++;
        }
        
        _isSpawning = false;
    }

    private bool AreEnemiesDead()
    {
        if (_count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
