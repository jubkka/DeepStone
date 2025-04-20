using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotate : InputControl
{
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float upperVerticalRotationLimit; 
    [SerializeField] private float lowerVerticalRotationLimit; 
    
    private GameObject player;
    private Camera playerCamera;

    private Vector2 rotateInput;
    
    private float xRotation;
    private float yRotation;
    
    protected override void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCamera = Camera.main;

        base.Start();
    }

    protected override void SubscribeToControls()
    {
        controls.Player.Rotate.canceled += OnRotate;
        controls.Player.Rotate.performed += OnRotate;
        controls.Player.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Player.Rotate.canceled -= OnRotate;
        controls.Player.Rotate.performed -= OnRotate;
        controls.Player.Disable();
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        rotateInput = context.ReadValue<Vector2>();
    }
    
    private void Update() => Rotate();

    private void Rotate() 
    {
        xRotation -= rotateInput.y * mouseSensitivity * Time.deltaTime;
        yRotation += rotateInput.x * mouseSensitivity * Time.deltaTime;

        xRotation = Mathf.Clamp(xRotation, -lowerVerticalRotationLimit, upperVerticalRotationLimit);
        
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
