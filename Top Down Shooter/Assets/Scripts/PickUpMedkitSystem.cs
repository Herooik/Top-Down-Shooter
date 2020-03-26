using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMedkitSystem : MonoBehaviour
{
    private PlayerHealthSystem playerHealthSystem;
    [SerializeField] private float healAmount = 50;

    private void Awake()
    {
        playerHealthSystem = FindObjectOfType<PlayerHealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           playerHealthSystem.HealPlayer(healAmount);
           
           gameObject.SetActive(false);
            
            // play pick up medkit sound 
        }
    }
}
