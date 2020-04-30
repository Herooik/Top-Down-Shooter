                                                                using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private float _weaponDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<EnemyHealthSystem>();
        
        if (enemy != null)
        {
            gameObject.SetActive(false);

            _weaponDamage = WeaponChange.Instance.SelectedWeapon.damage;

            enemy.TakeDamage(_weaponDamage);
        }
    }
}
