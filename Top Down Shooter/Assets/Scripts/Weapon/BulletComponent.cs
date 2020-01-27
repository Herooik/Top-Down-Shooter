using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private string _tagObjectToDealDamage;

    private void DealDamage(Collider2D target)
    {
        HealthSystem targetObject = target.gameObject.GetComponent<HealthSystem>();
        if (targetObject != null)
        {
            targetObject.TakeDamage(_weapon.damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_tagObjectToDealDamage))
        {
            GameObject bulletEfect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(bulletEfect, 0.5f);
            Destroy(gameObject);
            DealDamage(other);
        }
    } 
}
