using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        
        Debug.Log(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemySpawnManager.Instance._enemyCount--;
       
       CreateExplosion();

       gameObject.SetActive(false);
       
       _currentHealth = _maxHealth;
    }

    private void CreateExplosion()
    {
         var bulletEffect = ObjectPooler.Instance.GetPooledObject("Enemy Explosion");

        if (bulletEffect != null)
        {
            bulletEffect.transform.position = transform.position;
            bulletEffect.SetActive(true);
        }  
    }
}
