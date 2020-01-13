using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform _firePont;
    [SerializeField] private GameObject[] _bulletPrefab;
    [SerializeField] private Weapon[] _weapon;
    
    private GameObject _bullet;

    private string _input;
    private int _numericInput;

    private void Start()
    {
        _bullet = _bulletPrefab[0];
    }

    void Update()
    {
        GetNumericKeyInput();

        Shoot();
    }

    private void GetNumericKeyInput()
    {
        _input = Input.inputString;
        int.TryParse(_input, out _numericInput);
        if (_numericInput >= 1 && _numericInput <= _weapon.Length)
        {
            ChangeWeapon(_numericInput);
        }
    }


    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InitializeShoot();
        }
    }

    private void InitializeShoot()
    {
        GameObject bullet = Instantiate(_bullet, _firePont.position, _firePont.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePont.up * -_weapon[_numericInput].bulletSpeed, ForceMode2D.Impulse);
    }
    
    private void ChangeWeapon(int element)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _weapon[element - 1].attachToBody;
        _bullet = _bulletPrefab[element - 1];
    }
}
