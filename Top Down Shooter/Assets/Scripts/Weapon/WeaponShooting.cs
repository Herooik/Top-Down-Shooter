using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponShooting : MonoBehaviour
{
    public PlayerController pc;
    [HideInInspector] public bool isShooting = false;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponChange weaponChange;
    [SerializeField] private PlayerEnergySystem playerEnergySystem;
    
    private float _nextTimeToFire = 0f;
    

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            isShooting = true;

            _nextTimeToFire = Time.time + 1f / weaponChange.SelectedWeapon.fireRate;

            playerEnergySystem.AbsorbEnergy(weaponChange.SelectedWeapon.energyConsumption);

            InitializeShoot();
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
    }

    private void InitializeShoot()
    {
       var bullet = PlayerBulletPool.Instance.GetPooledObject();

       if (bullet != null)
       {
           bullet.transform.rotation = firePoint.rotation;
           bullet.transform.position = firePoint.position;
           bullet.SetActive(true);
       }

       var rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * -weaponChange.SelectedWeapon.bulletSpeed, ForceMode2D.Impulse);
    }
}
