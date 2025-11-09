using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
   // public Vector3 JumpForce = 7;

    private Rigidbody rb;
    private CharacterController controller;
    private PlayerControls controlls;
    private Vector2 moveInput;
    private Vector3 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        controlls = new PlayerControls(); 
    }

    private void OnEnable()
    {
      //  controlls.Player3D.Jump.performed += 
        //controlls.Player3D.Enable();
        controlls.Player3D.Move.performed += OnMovePerformed;
        controlls.Player3D.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        controlls.Player3D.Move.performed -= OnMovePerformed;
        controlls.Player3D.Move.canceled -= OnMoveCanceled;
        controlls.Player3D.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void Update()
    {
        JumpPlayer();
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
    }

    public void JumpPlayer()
    {
        Vector3 jump = new Vector3(0, 0, moveInput.y);
        
    }
}