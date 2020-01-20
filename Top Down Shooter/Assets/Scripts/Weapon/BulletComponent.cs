using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Weapon _weapon;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject bulletEfect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
        Destroy(bulletEfect, 0.5f);
        Destroy(gameObject);
        DealDamage(other);
    }

    private void DealDamage(Collision2D target)
    {
        HealthSystem targetObject = target.gameObject.GetComponent<HealthSystem>();
        if (targetObject != null)
        {
            targetObject.TakeDamage(_weapon.damage);
        }
    }
}
