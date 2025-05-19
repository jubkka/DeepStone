using System;
using UnityEngine;

public class HotbarInputUI : MonoBehaviour
{
    [SerializeField] private Transform slots;
    [SerializeField] private GameObject activeSlot;
    
    private int activeSlotIndex;
    private HotbarInput input;
    
    public event Action<int> OnMouseScrolled;

    private void Start()
    {
        input = GetComponent<HotbarInput>();
        
        input.OnSlotSelected += MoveSlot;
        input.OnMouseScrolled += ScrollSlot;
    }

    private void MoveSlot(int index) 
    {
        activeSlot.transform.SetParent(slots.transform.GetChild(index));
        activeSlot.transform.position = slots.transform.GetChild(index).transform.position;

        activeSlotIndex = index;
    }

    private void ScrollSlot(float value)
    {
        int index = activeSlotIndex;
        
        if (value < 0f) 
            index = activeSlotIndex != 4 ? activeSlotIndex + 1 : 0;
        else if (value > 0f)
            index = activeSlotIndex != 0 ? activeSlotIndex - 1 : 4;
        
        MoveSlot(index);
        
        OnMouseScrolled?.Invoke(index);
    }
}