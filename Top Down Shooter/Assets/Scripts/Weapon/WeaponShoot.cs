using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShoot : MonoBehaviour
{
    [HideInInspector] public GameObject _bullet;
    [HideInInspector] public bool isShooting = false;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponChange weaponChange;
    [SerializeField] private AmmoSystem ammoSystem;
    
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
            
            ammoSystem.AbsorbAmmo(weaponChange._selectedWeapon.ammoConsumption);

            InitializeShooting();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    private void InitializeShooting()
    {
       var bullet = PlayerBulletPooler.Instance.GetPooledObject();

       if (bullet != null)
       {
           bullet.transform.position = firePoint.transform.position;
           bullet.transform.rotation = firePoint.transform.rotation;
           bullet.SetActive(true);
       }

        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * -weaponChange._selectedWeapon.bulletSpeed, ForceMode2D.Impulse);
    }
}
