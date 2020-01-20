using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponReload : MonoBehaviour
{
    [SerializeField] private WeaponShoot weaponShoot;
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private TextMeshProUGUI _currentAmmoText;
    
    private bool _isReloading = false;

    private void Awake()
    {
        _weaponChange._weapons[0].currentAmmo = _weaponChange._weapons[0].maxAmmo;
    }

    public bool CheckForAmmoAmount(int numberOfChoosenWeapon)
    {
        if (_isReloading)
        {
            return true;
        }
        
        if (_weaponChange._weapons[numberOfChoosenWeapon - 1].currentAmmo <= 0)
        {
            StartCoroutine(Reload(weaponShoot._typeOfWeapon));
            return true;
        }

        return false;
    }

    private IEnumerator Reload(int numberOfChoosenWeapon)
    {
        _isReloading = true;

        yield return new WaitForSeconds(_weaponChange._weapons[numberOfChoosenWeapon - 1].reloadTime);

        _weaponChange._weapons[numberOfChoosenWeapon - 1].currentAmmo =
            _weaponChange._weapons[numberOfChoosenWeapon - 1].maxAmmo;
        
        _currentAmmoText.text = "Ammo: " + _weaponChange._weapons[numberOfChoosenWeapon - 1].currentAmmo + "/"
                                + _weaponChange._weapons[numberOfChoosenWeapon - 1].maxAmmo;

        _isReloading = false;
    }
}
