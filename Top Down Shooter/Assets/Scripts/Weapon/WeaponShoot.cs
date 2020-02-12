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
    [SerializeField] private WeaponReload _weaponReload;
    [SerializeField] private TextMeshProUGUI _currentAmmoText;
    
    [HideInInspector] public GameObject _bullet;
    
    [HideInInspector] public int _typeOfWeapon = 1;
    private float _nextTimeToFire = 0f;
    [HideInInspector] public bool _isShooting = false;

    private void Awake()
    {
        _currentAmmoText.text = "Ammo: " + _weaponChange._weapons[_typeOfWeapon - 1].currentAmmo + "/"
                                + _weaponChange._weapons[_typeOfWeapon - 1].maxAmmo;
    }

    void Update()
    {
        if (_weaponReload.CheckForAmmoAmount(_typeOfWeapon))
        {
            _isShooting = false;
            return;
        }

        Shooting(_typeOfWeapon);
    }

    public void Shooting(int numberOfChoosenWeapon)
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            _isShooting = true;
            
            _nextTimeToFire = Time.time + 1f / _weaponChange._weapons[numberOfChoosenWeapon - 1].fireRate;

            InitializeShooting(numberOfChoosenWeapon);

            _weaponChange._weapons[numberOfChoosenWeapon - 1].currentAmmo--;
            
            _currentAmmoText.text = "Ammo: " + _weaponChange._weapons[numberOfChoosenWeapon - 1].currentAmmo + "/"
                                    + _weaponChange._weapons[numberOfChoosenWeapon - 1].maxAmmo;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            _isShooting = false;
        }
    }

    private void InitializeShooting(int numberOfChoosenWeapon)
    {
        GameObject bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * -_weaponChange._weapons[numberOfChoosenWeapon - 1].bulletSpeed, ForceMode2D.Impulse);
    }
}
