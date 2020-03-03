using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;

    private EnemySpawnManager _EnemySpawnManager;

    private void Awake()
    {
        _EnemySpawnManager = FindObjectOfType<EnemySpawnManager>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log(_currentHealth);
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       _EnemySpawnManager._count--;
       Destroy(gameObject);
    }
}
