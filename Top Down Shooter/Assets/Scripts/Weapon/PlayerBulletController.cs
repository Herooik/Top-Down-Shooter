                                                                using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private float _weaponDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

            _weaponDamage = WeaponChange.Instance._selectedWeapon.damage;

            other.gameObject.GetComponent<EnemyHealthSystem>().TakeDamage(_weaponDamage);
        }
    }
}
