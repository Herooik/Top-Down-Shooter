using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceContainer : MonoBehaviour
{
    private static ReferenceContainer _instance;

    public static ReferenceContainer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Instance;
            }

            return _instance;
        }
    }

    public PlayerController playerController;
    public PlayerHealthSystem playerHealthSystem;
    public PlayerEnergySystem playerEnergySystem;

    private void Awake()
    {
        _instance = this;
    }
}
