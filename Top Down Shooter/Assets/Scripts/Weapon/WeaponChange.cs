using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{ 
    [SerializeField] private WeaponShoot weaponShoot;
   // [SerializeField] private WeaponReload _weaponReload;
   // [SerializeField] private TextMeshProUGUI _currentAmmoText;

    [SerializeField] private Weapon[] _weapon;
    [SerializeField] private GameObject[] _bullet;

    [HideInInspector] public Weapon _selectedWeapon;

    private string _input;
    private int _numericInput;

    private void Awake()
    {
        _selectedWeapon = _weapon[0];
        weaponShoot._bullet = _bullet[0];
    }

    private void Update()
    {
        // if (_weaponReload.CheckForAmmoAmount()) return;

        GetNumericKeyInput();
    }

    private void GetNumericKeyInput()
    {
        _input = Input.inputString;
        int.TryParse(_input, out _numericInput);

        if (_numericInput >= 1 && _numericInput <= _weapon.Length)
        {
            SwitchWeapon(_numericInput);

            //weaponShoot._typeOfWeapon = _numericInput;
        }
    }

    private void SwitchWeapon(int numberOfChoosenWeapon)
    {
        _selectedWeapon = _weapon[numberOfChoosenWeapon - 1];
        
        gameObject.GetComponent<SpriteRenderer>().sprite = _selectedWeapon.attachToBodySprite;
        
       // _currentAmmoText.text = "Ammo: " + _selectedWeapon.currentAmmo + "/" + _selectedWeapon.maxAmmo;

        weaponShoot._bullet = _bullet[numberOfChoosenWeapon - 1];
    }
}
