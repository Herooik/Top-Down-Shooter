using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.5f;
    [SerializeField] private float moveSpeedWhileShooting = 1f;

    [SerializeField] private Rigidbody2D newRigidbody2D;
    [SerializeField] private Animator animator;
    [SerializeField] private WeaponShoot weaponShoot;

    [SerializeField] private Texture2D aimTexture;

    private Vector2 _playerMovement;
    private Vector2 _mousePosition;

    private float _basicMoveSpeed;

    private void Start()
    {
        var cursorHotspot = new Vector2(aimTexture.width / 2, aimTexture.height / 2);
        Cursor.SetCursor(aimTexture, cursorHotspot, CursorMode.Auto);

        _basicMoveSpeed = moveSpeed;
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
            animator.SetBool("isMoving", false);
        else
            animator.SetBool("isMoving", true);

        newRigidbody2D.MovePosition(newRigidbody2D.position + _playerMovement * moveSpeed * Time.fixedDeltaTime);
    }

    private void SlowDownMovement()
    {
        if (weaponShoot.isShooting)
            moveSpeed = moveSpeedWhileShooting;
        else
            moveSpeed = _basicMoveSpeed;
    }

    private void PlayerAiming()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var lookDirection = _mousePosition - newRigidbody2D.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
        newRigidbody2D.rotation = angle;
    }
}