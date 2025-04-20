using UnityEngine.InputSystem;

public class AttackInput : InputControl
{
    private HandComponent hand;
    
    protected override void Start()
    {
        hand = GameSystems.Instance.GetHandComponent;

        base.Start();
    }

    protected override void SubscribeToControls()
    {
        controls.Player.Attack.performed += OnAttack;
        controls.Player.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Player.Attack.performed -= OnAttack;
        controls.Player.Disable();
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        hand.UseItemInHand();
    }
}