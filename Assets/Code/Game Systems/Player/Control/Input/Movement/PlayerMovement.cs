using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder;

public class PlayerMovement : InputControl
{
    [Header("Components")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private CameraShaker shaker;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float baseMoveSpeed = 7f;
    [SerializeField] private float minSpeed = 2f;
    
    [Header("Walk Sound")]
    [SerializeField] private float baseFootstepDelay = 0.4f;
    [SerializeField] private float minFootstepDelay = 0.2f;
    [SerializeField] private float maxFootstepDelay = 0.6f;
    
    private float footstepTimer = 0f;
    private Vector2 moveInput;

    private Attribute dexterity;
    private WeightComponent weightComponent;

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

    public void Initialize(AttributeComponent attribute, WeightComponent weight)
    {
        weightComponent = weight;
        dexterity = attribute.GetAttribute(AttributeType.Dexterity);

        dexterity.OnAttributeChanged += _ => ChangeSpeed();
        weightComponent.OnWeightCurrentChanged += _ => ChangeSpeed();

        ChangeSpeed();
    }

    private void ChangeSpeed()
    {
        float dexterityBonus = 1f + (dexterity.Value * 0.005f);
        float speed = baseMoveSpeed * dexterityBonus;
        
        if (weightComponent.GetCurrentWeight > weightComponent.GetMaxWeight)
        {
            float difference = weightComponent.GetCurrentWeight - weightComponent.GetMaxWeight;
            float overWeight = Mathf.Clamp01(difference / weightComponent.GetMaxWeight);
            float slowDown = Mathf.Lerp(speed, minSpeed,overWeight);
            
            moveSpeed = slowDown;
            return;
        }
        
        moveSpeed = speed;
    }

    private void Update() => Move();

    private void Move()
    {
        Vector3 move = controller.transform.right * moveInput.x +
                       controller.transform.forward * moveInput.y;
        
        float currentSpeed = controller.velocity.magnitude;

        controller.Move(move * moveSpeed * Time.deltaTime);
        shaker.DecideShake(moveInput.sqrMagnitude);

        WalkSound(currentSpeed);
    }

    private void WalkSound(float currentSpeed)
    {
        if (currentSpeed >= 0.1f)
        {
            float adjustedDelay = Mathf.Clamp(baseFootstepDelay * (moveSpeed / currentSpeed),
                minFootstepDelay, maxFootstepDelay);

            footstepTimer += Time.deltaTime;
            if (footstepTimer >= adjustedDelay)
            {
                footstepTimer = 0f;
                SFXAudioManager.Instance.PlaySound("Footstep");
            }
        }
        else
            footstepTimer = 0f;
    }
}
