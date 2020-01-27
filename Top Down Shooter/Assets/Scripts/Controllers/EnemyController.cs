using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _stoppingDistance = 2f;
    [SerializeField] private float _retreatDistance = 1f;

     private Transform _player;

     private void Start()
     {
         _player = GameObject.FindGameObjectWithTag("Player").transform;
     }

     void Update()
    {
        FollowPlayer();
        LookAtPlayer();
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, _player.position) > _stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, _moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, _player.position) < _stoppingDistance &&
                 Vector2.Distance(transform.position, _player.position) > _retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, _player.position) < _retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.position, -_moveSpeed * Time.deltaTime);
        }
    }

    private void LookAtPlayer()
    {
        var direction = _player.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
