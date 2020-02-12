using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float _startHealth = 100f;
    private float _currentHealth;
    [SerializeField] private Image _healthBar;

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        _healthBar.fillAmount = _currentHealth / _startHealth;
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
