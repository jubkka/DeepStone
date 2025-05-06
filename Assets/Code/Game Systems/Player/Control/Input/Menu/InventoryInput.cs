using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryInput : InputControl
{
    [SerializeField] private CanvasGroup gearUI;
    
    private bool isInventoryOpen = false;

    protected override void SubscribeToControls()
    {
        controls.Player.ToggleInventory.performed += OnToggle;
        controls.Inventory.Close.performed += OnClose;
        
        controls.Player.Enable();
        controls.Inventory.Enable();
    }
    
    protected override void UnsubscribeFromControls()
    {
        controls.Player.ToggleInventory.performed -= OnToggle;
        controls.Inventory.Close.performed -= OnClose;
        
        controls.Player.Enable();
        controls.Inventory.Disable();
    }

    private void OnToggle(InputAction.CallbackContext context)
    {
        Toggle();
    }
    
    private void OnClose(InputAction.CallbackContext context)
    {
        isInventoryOpen = false;
        
        Close();
    }

    public void Toggle()
    {
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen)
            Open();
        else
            Close();
    }
    
    private void Close()
    {
        inputManager.SwitchToPlayer();
        gearUI.alpha = 0f;
    }

    private void Open()
    {
        inputManager.SwitchToInventory();
        gearUI.alpha = 1f;
    }
}