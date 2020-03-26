using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private float maxHealth = 200f;
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    [HideInInspector] public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;

        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void HealPlayer(float healAmount)
    {
        var healthMissing = maxHealth - currentHealth;

        if (healthMissing < healAmount)
        {
            currentHealth += healthMissing;
        }
        else
        {
            
            currentHealth += healAmount;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;

        healthText.text = currentHealth + "/" + maxHealth;
    }
}
