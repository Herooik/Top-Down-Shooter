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
        CreateExplosion();
        
        EnemySpawnManager.Instance._enemyCount--;

        gameObject.SetActive(false);
        
        EnemyDropSystem.Instance.DropMedkit(transform.position);
    }

    private void CreateExplosion()
    {
        var bulletEffect = EnemyExplosionPool.Instance.GetPooledObject();

        if (bulletEffect != null)
        {
            bulletEffect.transform.position = transform.position;
            bulletEffect.SetActive(true);
        }  
    }
}
