using UnityEngine;
using UnityEngine.InputSystem;

public class CastInput : InputControl
{
    [SerializeField] private MagicHandComponent magicHand;
    
    protected override void Start()
    {
        magicHand = CombatSystems.Instance.GetMagicHand;

        base.Start();
    }
    
    protected override void SubscribeToControls()
    {
        controls.Player.Cast.performed += OnCast;
        controls.Player.Cast.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Player.Cast.performed -= OnCast;
        controls.Player.Cast.Disable();
    }

    private void OnCast(InputAction.CallbackContext action)
    {
        magicHand.UseItemInHand();
    }
}