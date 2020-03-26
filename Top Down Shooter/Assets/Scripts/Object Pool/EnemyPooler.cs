using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
    public GameObject objectContainer;
}

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler Instance;
    
    [SerializeField] private List<EnemyPoolItem> itemsToPool;
    
    private List<GameObject> _pooledObjects;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }


    public void Start()
    {
        _pooledObjects = new List<GameObject>();

        foreach (var item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                var obj = Instantiate(item.objectToPool, item.objectContainer.transform);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(GameObject objectToPool)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        foreach (var item in itemsToPool)
        {
            if (item.shouldExpand)
            {
                var obj = Instantiate(objectToPool, item.objectContainer.transform);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
                return obj;
            }
        }

        return null;
    }
    
}
