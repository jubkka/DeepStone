using UnityEngine.InputSystem;

public class UseItemInHandInput : InputControl
{
    private RightHandComponent rightHand;
    
    protected override void Start()
    {
        rightHand = CombatSystems.Instance.GetRightHand;

        base.Start();
    }

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