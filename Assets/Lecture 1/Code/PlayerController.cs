using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float moveSpeed = 5f;
    private InputAction _moveAction;

    private void Awake()
    {
        _moveAction = playerInput.actions["Move"];
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = _moveAction.ReadValue<float>();
        transform.Translate(moveInput * moveSpeed * Time.deltaTime, 0, 0);
    }
}
