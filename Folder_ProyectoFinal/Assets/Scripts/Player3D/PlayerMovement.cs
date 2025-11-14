using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerControls controls;
    private Vector2 moveInput;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("GroundCheck")]
    [SerializeField] Transform groundCheck;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundMask;

    private bool isGround;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new PlayerControls();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        GroundChech();
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Move.performed += OnMovePerformed;
        controls.Player.Move.canceled += OnMoveCanceled;
        controls.Player.Jump.performed += OnJump;
    }
    private void OnDisable()
    {
        controls.Disable();
        controls.Player.Move.performed -= OnMovePerformed;
        controls.Player.Move.canceled -= OnMoveCanceled;
        controls.Player.Jump.performed -= OnJump;
    }

    private void OnMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }    

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = Vector2.zero;
    }

    private void MovePlayer()
    {

        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);

        rb.AddForce(move * moveSpeed, ForceMode.Impulse);

        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitedVelocity.x, rb.linearVelocity.y, limitedVelocity.z);
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGround)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void GroundChech()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}