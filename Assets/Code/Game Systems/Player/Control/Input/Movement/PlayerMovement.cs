using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : InputControl
{
    [SerializeField] private float moveSpeed = 5f;
    
    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 moveDirection;

    protected override void Start()
    {
        controller = GetComponentInParent<CharacterController>();
        
        base.Start();
    }

    protected override void SubscribeToControls()
    {
        controls.Player.Move.canceled += OnMove;
        controls.Player.Move.performed += OnMove;
        controls.Player.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;
        controls.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
    private void Update() => Move();
    
    private void Move()
    {
        Vector3 move = controller.transform.right * moveInput.x + controller.transform.forward * moveInput.y;
        
        controller.Move(move * moveSpeed * Time.deltaTime);
    }
}
