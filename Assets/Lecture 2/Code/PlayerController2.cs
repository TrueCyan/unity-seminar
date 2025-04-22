using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _jumpAction.performed += OnJump;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = _moveAction.ReadValue<float>();
        _rigidbody.linearVelocity = new Vector2(moveInput * moveSpeed, _rigidbody.linearVelocity.y);
    }

    void OnJump(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
