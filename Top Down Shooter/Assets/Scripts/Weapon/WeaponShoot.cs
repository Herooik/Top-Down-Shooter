using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShoot : MonoBehaviour
{
    [HideInInspector] public bool isShooting = false;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponChange weaponChange;
    [SerializeField] private PlayerEnergySystem playerEnergySystem;
    
    private float _nextTimeToFire = 0f;
    

    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            isShooting = true;
            
            _nextTimeToFire = Time.time + 1f / weaponChange._selectedWeapon.fireRate;
            
            playerEnergySystem.AbsorbAmmo(weaponChange._selectedWeapon.ammoConsumption);

            InitializeShooting();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    private void InitializeShooting()
    {
       var bullet = PlayerBulletPool.Instance.GetPooledObject();

       if (bullet != null)
       {
           bullet.transform.position = firePoint.transform.position;
           bullet.transform.rotation = firePoint.rotation;
           bullet.SetActive(true);
       }

       var rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * -weaponChange._selectedWeapon.bulletSpeed, ForceMode2D.Impulse);
    }
}
