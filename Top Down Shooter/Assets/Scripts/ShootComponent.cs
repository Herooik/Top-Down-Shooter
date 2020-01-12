using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] private Transform _firePont;
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private float _bulletForce = 20f;

    private float _damage = 10f;
    private float _range = 100f;
    private float _fireRate = 10f;
    private int _ammo = 30;

    // Update is called once per frame
    void Update()
    {
        Shoot();
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
        GameObject bullet = Instantiate(_bulletPrefab, _firePont.position, _firePont.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePont.up * -_bulletForce, ForceMode2D.Impulse);
    }
}
