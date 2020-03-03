using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.5f;
    [SerializeField] private float _moveSpeedWhileShooting = 1f;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator _animator;
    [SerializeField] private WeaponShoot _weaponShoot;

    [SerializeField] private Texture2D _aimTexture;

    private Vector2 _playerMovement;
    private Vector2 _mousePosition;

    private float _basicMoveSpeed;

    private void Start()
    {
        var cursorHotspot = new Vector2(_aimTexture.width / 2, _aimTexture.height / 2);
        Cursor.SetCursor(_aimTexture, cursorHotspot, CursorMode.Auto);

        _basicMoveSpeed = _moveSpeed;
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void Update()
    {
        SlowDownMovement();

        PlayerAiming();
    }

    private void PlayerMovement()
    {
        _playerMovement.x = Input.GetAxisRaw("Horizontal");
        _playerMovement.y = Input.GetAxisRaw("Vertical");
        
        _playerMovement.Normalize();

        if (_playerMovement == new Vector2(0, 0))
            _animator.SetBool("isMoving", false);
        else
            _animator.SetBool("isMoving", true);

        _rigidbody2D.MovePosition(_rigidbody2D.position + _playerMovement * _moveSpeed * Time.fixedDeltaTime);
    }

    private void SlowDownMovement()
    {
        if (_weaponShoot._isShooting)
            _moveSpeed = _moveSpeedWhileShooting;
        else
            _moveSpeed = _basicMoveSpeed;
    }

    private void PlayerAiming()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var lookDirection = _mousePosition - _rigidbody2D.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        _rigidbody2D.rotation = angle;
    }
}