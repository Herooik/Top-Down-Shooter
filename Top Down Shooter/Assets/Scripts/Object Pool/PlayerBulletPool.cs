using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPoolItem
{
    public GameObject objectToPool;
    public int amountToPool;
    public bool shouldExpand = true;
    public GameObject objectContainer;
}

public class PlayerBulletPool : MonoBehaviour
{
    public static PlayerBulletPool Instance { get; private set; }
    
    [SerializeField] private List<BulletPoolItem> itemsToPool;
    
    private List<GameObject> _pooledObjects;
    

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

        int j = 0;
        
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

    public GameObject GetPooledObject()
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
                var obj = Instantiate(item.objectToPool, item.objectContainer.transform);
                obj.SetActive(false);
                _pooledObjects.Add(obj);
                return obj;
            }
        }

        return null;
    }

    public void ChangeInactiveBulletSprite(Sprite newSprite)
    {
        foreach (var item in itemsToPool)
        {
            for (int i = 0; i < _pooledObjects.Count; i++)
            {
                if (!_pooledObjects[i].activeInHierarchy)
                {
                    _pooledObjects[i].gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
                }
            }
        }
    }
    
}

