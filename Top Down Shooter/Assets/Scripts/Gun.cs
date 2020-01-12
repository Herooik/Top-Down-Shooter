using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _firePont;
    [SerializeField] private GameObject[] _bulletPrefab;

    [SerializeField] private float _bulletForce = 20f;

    [SerializeField]private Sprite[] _gunSprites;
    private GameObject _bullet;
    
    void Update()
    {
        ChangeWeapon();
        Shoot();
    }

    private void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _gunSprites[0];
            _bullet = _bulletPrefab[0];
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _gunSprites[1];
            _bullet = _bulletPrefab[1];
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
        rb.AddForce(_firePont.up * -_bulletForce, ForceMode2D.Impulse);
    }
}
