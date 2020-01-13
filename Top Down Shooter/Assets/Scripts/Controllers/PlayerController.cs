using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;

    private Vector2 _playerMovement;
    private Vector2 _mousePosition;

    private void FixedUpdate()
    {
        PlayerMovement();

        PlayerAiming();
    }

    private void PlayerMovement()
    {
        _playerMovement.x = Input.GetAxisRaw("Horizontal");
        _playerMovement.y = Input.GetAxisRaw("Vertical");
        
        if (_playerMovement == new Vector2(0, 0))
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }

        _rigidbody2D.MovePosition(_rigidbody2D.position + _playerMovement * _moveSpeed * Time.fixedDeltaTime);
    }

    private void PlayerAiming()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = _mousePosition - _rigidbody2D.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        _rigidbody2D.rotation = angle;
    }
}
