using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _stoppingDistance = 0.5f;

     private Transform _player;

     private void Start()
     {
         _player = GameObject.FindGameObjectWithTag("Player").transform;
     }

     void Update()
    {
        if (_player != null)
        {
            FollowPlayer();
            LookAtPlayer();
        }
    }

    private void FollowPlayer()
    {
       if (Vector2.Distance(transform.position, _player.position) >= _stoppingDistance)
       {
           transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
       }
    }

    private void LookAtPlayer()
    {
        var direction = _player.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
