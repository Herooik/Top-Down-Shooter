using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private PlaySoundSystem playSoundSystem;
    [SerializeField] private float healAmount = 50;
    
    private PlayerHealthSystem _playerHealthSystem;

    private void Awake()
    {
        _playerHealthSystem = FindObjectOfType<PlayerHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           _playerHealthSystem.HealPlayer(healAmount);
           
           playSoundSystem.PlaySound();
           
           gameObject.SetActive(false);
        }
    }
}
