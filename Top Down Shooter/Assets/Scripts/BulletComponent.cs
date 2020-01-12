﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject bulletEfect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(bulletEfect, 0.5f);
        Destroy(gameObject);
        DealDamage(other);
        
    }

    private void DealDamage(Collision2D target)
    {
        Enemy enemy = target.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }
    }

}