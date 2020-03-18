using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    private float weaponDamage;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

            weaponDamage = WeaponChange.instance._selectedWeapon.damage;

            other.gameObject.GetComponent<EnemyHealthSystem>().TakeDamage(weaponDamage);
        }
    }
}
