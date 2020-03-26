using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyDropSystem : MonoBehaviour
{
    [SerializeField] private float medkitDropRate = 60f;

    public static EnemyDropSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void DropMedkit(Vector3 enemyPosition)
    {
        if (Random.Range(0, 100) > medkitDropRate)
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

    public void DropEnergy()
    {
        
    }

    public void DropGold()
    {
        
    }
}
