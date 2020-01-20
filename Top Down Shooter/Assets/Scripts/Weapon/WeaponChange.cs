using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{ 
    [SerializeField] private WeaponShoot weaponShoot;
    [SerializeField] private WeaponReload _weaponReload;
    [SerializeField] private TextMeshProUGUI _currentAmmoText;

    public Weapon[] _weapons;
    public GameObject[] _bullets;

    private string _input;
    private int _numericInput;

    private void Awake()
    {
        weaponShoot._bullet = _bullets[0];
    }

    private void Update()
    {
        if (_weaponReload.CheckForAmmoAmount(weaponShoot._typeOfWeapon)) return;

        GetNumericKeyInput();
    }

    public void GetNumericKeyInput()
    {
        _input = Input.inputString;
        int.TryParse(_input, out _numericInput);

        if (_numericInput >= 1 && _numericInput <= _weapons.Length)
        {
            SwitchWeapon(_numericInput);

            weaponShoot._typeOfWeapon = _numericInput;
        }
    }

    private void SwitchWeapon(int numberOfChoosenWeapon)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _weapons[numberOfChoosenWeapon - 1].attachToBody;
        
        _currentAmmoText.text = "Ammo: " + _weapons[numberOfChoosenWeapon - 1].currentAmmo + "/" + _weapons[numberOfChoosenWeapon - 1].maxAmmo;

        weaponShoot._bullet = _bullets[numberOfChoosenWeapon - 1];
    }
}
