using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots = 1f;
    [SerializeField] private float startTimeBetweenShots = 2f;
    [SerializeField] private float bulletSpeed;

    [SerializeField] private Transform firePoint;

    void Start()
    {
        timeBetweenShots = startTimeBetweenShots;
    }
    
    void Update()
    {
        CheckTimeBetweenShoot();
    }

    private void CheckTimeBetweenShoot()
    {
        if (timeBetweenShots <= 0)
        {
            timeBetweenShots = startTimeBetweenShots;

            InitializeBullet();
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    private void InitializeBullet()
    {
        var bullet = EnemyBulletPool.Instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.gameObject.SetActive(true);
        }

        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * -bulletSpeed, ForceMode2D.Impulse);
    }
}
