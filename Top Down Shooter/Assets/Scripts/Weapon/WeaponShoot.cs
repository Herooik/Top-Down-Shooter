using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
    [SerializeField] private Transform _firePont;
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private WeaponReload _weaponReload;
    
    [HideInInspector] public GameObject _bullet;
    [HideInInspector] public int _typeOfWeapon = 1;
    private float _nextTimeToFire = 0f;
    

    void Update()
    {
        if (_weaponReload.CheckForAmmoAmount(_typeOfWeapon)) return;

        Shoot(_typeOfWeapon);
    }

    private void Shoot(int numberOfChoosenWeapon)
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _weaponChange._weapon[numberOfChoosenWeapon - 1].fireRate;

            InitializeShoot(numberOfChoosenWeapon);

            _weaponChange._weapon[numberOfChoosenWeapon - 1].currentAmmo--;
        }
    }

    private void InitializeShoot(int numberOfChoosenWeapon)
    {
        GameObject bullet = Instantiate(_bullet, _firePont.position, _firePont.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePont.up * -_weaponChange._weapon[numberOfChoosenWeapon - 1].bulletSpeed, ForceMode2D.Impulse);
    }
}
