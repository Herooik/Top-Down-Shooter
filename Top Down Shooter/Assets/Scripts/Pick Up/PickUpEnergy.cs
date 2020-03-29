using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickUpEnergy : MonoBehaviour
{
    [SerializeField] private float energyAmount = 3f;
    private PlayerEnergySystem _playerEnergySystem;

    private void Awake()
    {
        _playerEnergySystem = FindObjectOfType<PlayerEnergySystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerEnergySystem.GiveEnergy(energyAmount);
           
            gameObject.SetActive(false);
            
            // play pick up ammo sound 
        }
    }
}
