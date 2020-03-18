using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour
{
    public PlayerHealthSystem PlayerHealthSystem;

    public static ReferenceHolder Instance;

    private void Awake()
    {
        Instance = this;
    }
}
