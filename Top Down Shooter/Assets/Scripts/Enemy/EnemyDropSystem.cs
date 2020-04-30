using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDropSystem : MonoBehaviour
{
    [Header("Medkit Drop Parameteres")]
    [SerializeField] private float medkitSpawnProbability = 0.6f;

    [Header("Ammo Drop Parameteres")]
    [SerializeField] private int minEnergyDrop = 2;
    [SerializeField] private int maxEnergyDrop = 10;
    
    [Header("Gold Drop Parameteres")]
    [SerializeField] private int minGoldDrop = 2;
    [SerializeField] private int maxGoldDrop = 10;

    public static EnemyDropSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void DropPickUps(Vector3 enemyPosition)
    {
        DropMedkit(enemyPosition);
        DropEnergy(enemyPosition);
        DropGold(enemyPosition);
    }

    private void DropMedkit(Vector3 enemyPosition)
    {
        if(Random.value < medkitSpawnProbability)
        {
            var medkit = MedkitDropPool.Instance.GetPooledObject();

            if (medkit != null)
            {
                medkit.transform.position = enemyPosition;
            
                medkit.gameObject.SetActive(true);
            }
        }
    }

    private void DropEnergy(Vector3 enemyPosition)
    {
        var energyAmount = Random.Range(minEnergyDrop, maxEnergyDrop);

        for (int i = 0; i < energyAmount; i++)
        {
            var energy = AmmoDropPool.Instance.GetPooledObject();

            if (energy != null)
            {
                energy.transform.position = enemyPosition;
            
                energy.gameObject.SetActive(true);
            }
        }
    }

    private void DropGold(Vector3 enemyPosition)
    {
        var goldAmount = Random.Range(minGoldDrop, maxGoldDrop);

        for (int i = 0; i < goldAmount; i++)
        {
            var gold = CoinDropPool.Instance.GetPooledObject();

            if (gold != null)
            {
                gold.transform.position = enemyPosition;
            
                gold.gameObject.SetActive(true);
            }
        }
    }
}
