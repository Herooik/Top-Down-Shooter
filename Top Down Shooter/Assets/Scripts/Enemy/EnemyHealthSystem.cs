using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 200f;
    private float _currentHealth;
    
    private void OnEnable()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        InitializeDeathVFX();
        
        EnemySpawnManager.EnemyCount--;

        gameObject.SetActive(false);
        
        EnemyDropSystem.Instance.DropPickUps(transform.position);
    }

    private void InitializeDeathVFX()
    {
        var deathVFX = EnemyExplosionPool.Instance.GetPooledObject();

        if (deathVFX != null)
        {
            deathVFX.transform.position = transform.position;
            deathVFX.SetActive(true);
        }  
    }
}
