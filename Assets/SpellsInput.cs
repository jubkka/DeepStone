using UnityEngine;
using UnityEngine.InputSystem;

public class SpellsInput : InputControl
{
    [SerializeField] private SpellsUI spellsUI;
    
    private bool isOpen = false;

    protected override void SubscribeToControls()
    {
        controls.Spells.Toggle.performed += OnToggle;
        
        controls.Spells.Toggle.Enable();
    }
    
    protected override void UnsubscribeFromControls()
    {
        controls.Spells.Toggle.performed -= OnToggle;
        
        controls.Spells.Toggle.Disable();
    }
    
    private void OnToggle(InputAction.CallbackContext ctx)
    {
        Toggle();
    }

    private void Toggle()
    {
        if (isOpen)
            spellsUI.Close();
        else
            spellsUI.Open();

        isOpen = !isOpen;
    }
}
