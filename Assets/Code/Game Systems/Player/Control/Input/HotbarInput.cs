using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarInput : InputControl
{
    private int activeSlotIndex = 0;
    public int ActiveSlotIndex
    {
       get => activeSlotIndex;
       private set
       {
           activeSlotIndex = value;
           OnActiveSlotChanged?.Invoke(activeSlotIndex);
       }
    }
    
    public event Action<int> OnActiveSlotChanged;

    protected override void Start()
    {
        HotbarComponent hotbar = GearSystems.Instance.GetHotbarComponent;
        hotbar.OnItemChanged += SelectSlot;
        
        base.Start();
    }

    protected override void SubscribeToControls()
    {
        controls.Hotbar.Scroll.performed += OnScroll;
        
        controls.Hotbar.Slot1.performed += OnSelectSlot;
        controls.Hotbar.Slot2.performed += OnSelectSlot;
        controls.Hotbar.Slot3.performed += OnSelectSlot;
        controls.Hotbar.Slot4.performed += OnSelectSlot;
        controls.Hotbar.Slot5.performed += OnSelectSlot;
        
        controls.Hotbar.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Hotbar.Scroll.performed -= OnScroll;
        
        controls.Hotbar.Slot1.performed -= OnSelectSlot;
        controls.Hotbar.Slot2.performed -= OnSelectSlot;
        controls.Hotbar.Slot3.performed -= OnSelectSlot;
        controls.Hotbar.Slot4.performed -= OnSelectSlot;
        controls.Hotbar.Slot5.performed -= OnSelectSlot;
        
        controls.Hotbar.Disable();
    }

    private void OnScroll(InputAction.CallbackContext context)
    {
        ScrollMouse(context.ReadValue<float>());
    }

    private void OnSelectSlot(InputAction.CallbackContext context)
    {
        string keyName = context.control.displayName;
        
        switch (keyName)
        {
            case "1": 
                SelectSlot(0); break;
            case "2": 
                SelectSlot(1); break;
            case "3":
                SelectSlot(2); break;
            case "4": 
                SelectSlot(3); break;
            case "5": 
                SelectSlot(4); break;
        }
    }

    private void SelectSlot(int index)
    {
        ActiveSlotIndex = index;
    }
    
    private void ScrollMouse(float scrollValue)
    {
        if (scrollValue == 0) return;

        if (scrollValue < 0f) 
            ActiveSlotIndex = ActiveSlotIndex != 4 ? ActiveSlotIndex + 1 : 0;

        else if (scrollValue > 0f)
            ActiveSlotIndex = ActiveSlotIndex != 0 ? ActiveSlotIndex - 1 : 4;
    }
}
