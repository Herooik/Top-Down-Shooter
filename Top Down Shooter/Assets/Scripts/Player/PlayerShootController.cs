using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerShootController : MonoBehaviour
{
    public bool isShooting { get; private set; }

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
        if(playerEnergySystem.CurrentEnergy < weaponChange.SelectedWeapon.energyConsumption)
            return;
        
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire && playerEnergySystem.CurrentEnergy >= 0)
        {
            isShooting = true;

            _nextTimeToFire = Time.time + 1f / weaponChange.SelectedWeapon.fireRate;

            playerEnergySystem.AbsorbEnergy(weaponChange.SelectedWeapon.energyConsumption);
            
            AudioSource.PlayClipAtPoint(weaponChange.SelectedWeapon.fireSound, transform.position);

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
