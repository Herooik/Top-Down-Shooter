using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
    public GameObject objectContainer;
}

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [SerializeField] private List<ObjectPoolItem> itemsToPool;

    public List<GameObject> _pooledObjects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
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

    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy && _pooledObjects[i].tag == tag)
            {
                return _pooledObjects[i];
            }
        }

        foreach (var item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    var obj = Instantiate(item.objectToPool, item.objectContainer.transform);
                    obj.SetActive(false);
                    _pooledObjects.Add(obj);
                    return obj;
                }
            }
        }

        return null;
    }
}
