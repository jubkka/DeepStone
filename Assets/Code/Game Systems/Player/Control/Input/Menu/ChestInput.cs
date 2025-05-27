using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInput : InputControl
{
    [SerializeField] private ChestComponent chest;
    [SerializeField] private ChestUI chestUI;

    [SerializeField] private InventoryInput inventory;
    
    private ChestInteractable activeChest;

    protected override void SubscribeToControls()
    {
        controls.Chest.Close.performed += OnClose;
        controls.Chest.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Chest.Close.performed -= OnClose;
        controls.Chest.Disable();
    }

    private void OnClose(InputAction.CallbackContext obj)
    {
        CloseChest();
    }

    public void OpenChest(ChestInteractable chestInteractable)
    {
        activeChest = chestInteractable;
        
        inventory.Toggle();
            
        chest.GiveItems(chestInteractable.ChestContainer.Items);
        chestUI.Show();
        
        inputManager.SwitchToChest();
    }

    private void CloseChest()
    {
        if (activeChest == null)
            return;
        
        inventory.Toggle();
        
        activeChest.SaveBackItems(chest.TakeItems());
        chestUI.Hide();
        
        activeChest = null;
    }
}