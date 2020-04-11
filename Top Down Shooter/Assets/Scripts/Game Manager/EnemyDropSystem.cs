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

    public static EnemyDropSystem Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void DropMedkit(Vector3 enemyPosition)
    {
        if(Random.value < medkitSpawnProbability)
        {
            PrepareMedkit(enemyPosition);
        }
    }

    private static void PrepareMedkit(Vector3 enemyPosition)
    {
        var medkit = MedkitDropPool.Instance.GetPooledObject();

        if (medkit != null)
        {
            medkit.transform.position = enemyPosition;
            
            medkit.gameObject.SetActive(true);
        }
    }

    public void DropEnergy(Vector3 enemyPosition)
    {
        var energyAmount = Random.Range(minEnergyDrop, maxEnergyDrop);

        for (int i = 0; i < energyAmount; i++)
        {
            var energy = AmmoDropPool.Instance.GetPooledObject();
            
            energy.transform.position = enemyPosition;
            
            energy.gameObject.SetActive(true);
        }
    }
}
