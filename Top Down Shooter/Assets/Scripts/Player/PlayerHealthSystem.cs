using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Image _healthBar;
    [SerializeField] private TextMeshProUGUI _healthText;

    private float _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthText.text = _currentHealth + "/" + _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        _healthBar.fillAmount = _currentHealth / _maxHealth;

        _healthText.text = _currentHealth + "/" + _maxHealth;

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
