using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private PlaySoundSystem playSoundSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CoinManager.Instance.AddGold();

            playSoundSystem.PlaySound();

            gameObject.SetActive(false);
        }
    }
}
