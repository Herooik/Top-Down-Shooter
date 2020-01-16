using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChange : MonoBehaviour
{ 
    [SerializeField] private WeaponShoot weaponShoot;
    [SerializeField] private WeaponReload _weaponReload;

    public Weapon[] _weapon;
    public GameObject[] _bulletPrefab;

    private string _input;
    private int _numericInput;

    private void Awake()
    {
        weaponShoot._bullet = _bulletPrefab[0];
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

        if (_numericInput >= 1 && _numericInput <= _weapon.Length)
        {
            SwitchWeapon(_numericInput);

            weaponShoot._typeOfWeapon = _numericInput;
        }
    }

    private void SwitchWeapon(int element)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _weapon[element - 1].attachToBody;

        weaponShoot._bullet = _bulletPrefab[element - 1];
    }
}
