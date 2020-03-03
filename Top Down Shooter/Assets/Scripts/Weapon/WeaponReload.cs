using System.Collections;
using TMPro;
using UnityEngine;

public class WeaponReload : MonoBehaviour
{
    /*
    [SerializeField] private WeaponShoot weaponShoot;
    [SerializeField] private WeaponChange _weaponChange;
    [SerializeField] private TextMeshProUGUI _currentAmmoText;

    private bool _isReloading;

    private void Awake()
    {
        _weaponChange._selectedWeapon.currentAmmo = _weaponChange._selectedWeapon.maxAmmo;
    }

    public bool CheckForAmmoAmount()
    {
        if (_isReloading) return true;

        if (_weaponChange._selectedWeapon.currentAmmo <= 0 ||
            (Input.GetKeyDown(KeyCode.R) && _weaponChange._selectedWeapon.currentAmmo !=
            _weaponChange._selectedWeapon.maxAmmo))
        {
            StartCoroutine(Reload());
            return true;
        }

        return false;
    }

    private IEnumerator Reload()
    {
        _isReloading = true;

        yield return new WaitForSeconds(_weaponChange._selectedWeapon.reloadTime);

        _weaponChange._selectedWeapon.currentAmmo =
            _weaponChange._selectedWeapon.maxAmmo;

        _currentAmmoText.text = "Ammo: " + _weaponChange._selectedWeapon.currentAmmo + "/"
                                + _weaponChange._selectedWeapon.maxAmmo;

        _isReloading = false;
    } */
}