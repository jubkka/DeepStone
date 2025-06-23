using UnityEngine;
using UnityEngine.InputSystem;

public class UseItemInHandInput : InputControl
{
    [SerializeField] private RightHandComponent rightHand;

    protected override void SubscribeToControls()
    {
        controls.Player.Attack.performed += OnUse;
        controls.Player.Attack.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Player.Attack.performed -= OnUse;
        controls.Player.Attack.Disable();
    }

    private void OnUse(InputAction.CallbackContext context)
    {
        rightHand.UseItemInHand();
    }
}