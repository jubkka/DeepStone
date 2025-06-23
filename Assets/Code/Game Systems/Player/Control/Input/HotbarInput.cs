using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarInput : InputControl
{
    [SerializeField] private HotbarComponent hotbar;
    
    private int activeSlotIndex = 0;
    public int ActiveSlotIndex
    {
       get => activeSlotIndex;
       private set
       {
           activeSlotIndex = value;
           OnSlotSelected?.Invoke(activeSlotIndex);
       }
    }
    
    public event Action<int> OnSlotSelected;
    public event Action<int> OnKeyPressed;
    public event Action<float> OnMouseScrolled;

    protected override void Start()
    {
        base.Start();
        
        hotbar.OnItemChanged += SelectSlot;
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
                KeyPressed(0); break;
            case "2":
                KeyPressed(1); break;
            case "3":
                KeyPressed(2); break;
            case "4":
                KeyPressed(3); break;
            case "5":
                KeyPressed(4); break;
        }
    }

    private void KeyPressed(int index)
    {
        OnKeyPressed?.Invoke(index);
        OnSlotSelected?.Invoke(index);
    }

    private void SelectSlot(int index)
    {
        ActiveSlotIndex = index;
    }
    
    private void ScrollMouse(float scrollValue)
    {
        if (scrollValue == 0) 
            return;
        
        OnMouseScrolled?.Invoke(scrollValue);
    }
}
