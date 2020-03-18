using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float _timeBetweenShots = 1f;
    [SerializeField] private float _startTimeBetweenShots = 2f;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private Transform _firePoint;
    
   // [SerializeField] private GameObject _bullet;

    void Start()
    {
        _timeBetweenShots = _startTimeBetweenShots;
    }
    
    void Update()
    {
        if (_timeBetweenShots <= 0)
        {
            _timeBetweenShots = _startTimeBetweenShots;
            
            var bullet = ObjectPooler.Instance.GetPooledObject("Enemy Bullet");
            if (bullet != null)
            {
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.rotation;
                bullet.SetActive(true);
            }
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_firePoint.up * -_bulletSpeed, ForceMode2D.Impulse);
        }
        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }
}
