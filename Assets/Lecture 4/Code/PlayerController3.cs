using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController3 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int maxAirJumps = 1;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private int _airJumpCount = 0;

    private void Awake()
    {
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _jumpAction.performed += OnJump;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = _moveAction.ReadValue<float>();
        _rigidbody.linearVelocity = new Vector2(moveInput * moveSpeed, _rigidbody.linearVelocity.y);
        _animator.SetBool("Moving", Mathf.Abs(moveInput) > 0.01f);
        _spriteRenderer.flipX = moveInput < 0;
        _animator.SetBool("Falling", _rigidbody.linearVelocity.y < -0.01f);
        if (IsGrounded())
        {
            _airJumpCount = 0;
        }
    }

    private bool IsGrounded()
    {
        List<Collider2D> results = new List<Collider2D>();
        _collider.Overlap(results);
        return results.Any(x => x.transform.position.y < transform.position.y);
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            Jump();
        }
        else if (_airJumpCount < maxAirJumps)
        {
            _airJumpCount++;
            Jump();
        }

    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0);
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animator.SetTrigger("Jump");
    }
}
