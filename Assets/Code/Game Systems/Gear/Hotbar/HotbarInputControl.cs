using System;
using UnityEngine;

public class HotbarInputControl : MonoBehaviour
{
    private int activeSlotIndex = 1;
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

    private void Start()
    {
        HotbarComponent hotbar = GameSystems.Instance.GetHotbarComponent;

        hotbar.OnItemChanged += SelectHotbarSlot;
        
        InputManager.Instance.OnHotbarKeyPressed += SelectHotbarSlot;
        InputManager.Instance.OnHotbarSlotsScrolled += ScrollMouse;
    }
    
    private void SelectHotbarSlot(int index)
    {
        ActiveSlotIndex = index;
    }
    
    private void ScrollMouse()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");

        if (scroll == 0) return;

        if (scroll < 0f) 
            ActiveSlotIndex = ActiveSlotIndex != 8 ? ActiveSlotIndex + 1 : 0;

        else if (scroll > 0f)
            ActiveSlotIndex = ActiveSlotIndex != 0 ? ActiveSlotIndex - 1 : 8;
    }
}
