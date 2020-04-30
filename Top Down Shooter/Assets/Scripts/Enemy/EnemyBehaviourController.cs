using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviourController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float stoppingDistance = 0.5f;

    private Transform _playerPosition;

    private void Start()
    {
        _playerPosition = ReferenceContainer.Instance.playerController.transform;
    }

    private void Update()
    {
        if (_playerPosition != null)
        {
            FollowPlayer();
            LookAtPlayer();
        }
    }

    private void FollowPlayer()
    {
        if (Vector2.Distance(transform.position, _playerPosition.position) >= stoppingDistance)
        {
            transform.position = Vector2.MoveTowards
                (transform.position, _playerPosition.position, moveSpeed * Time.deltaTime);
        }
    }

    private void LookAtPlayer()
    {
        var direction = _playerPosition.position - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
