using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private AmmoSystem _ammoSystem;
    
    [HideInInspector] public GameObject _bullet;
    
    private float _nextTimeToFire = 0f;
    [HideInInspector] public bool _isShooting = false;

    void Update()
    {
        Shooting();
    }

    private void Shooting()
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            _isShooting = true;
            
            _nextTimeToFire = Time.time + 1f / _weaponChange._selectedWeapon.fireRate;
            
            _ammoSystem.AbsorbAmmo(_weaponChange._selectedWeapon.ammoConsumption);

            InitializeShooting();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _isShooting = false;
        }
    }

    private void InitializeShooting()
    {
        GameObject bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * -_weaponChange._selectedWeapon.bulletSpeed, ForceMode2D.Impulse);
    }
}
