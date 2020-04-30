using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    [SerializeField] private PlaySoundSystem playSoundSystem;
    [SerializeField] private float energyAmountForPlayer = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ReferenceContainer.Instance.playerEnergySystem.GiveEnergy(energyAmountForPlayer);
            
            playSoundSystem.PlaySound();
           
            gameObject.SetActive(false);
        }
    }
}
