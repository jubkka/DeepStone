using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

public abstract class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IDropHandler
{
    [Header("Services")]
    protected GearComponent gear;
    public ItemSlotType itemSlotType;

    private void Start()
    {
        Initialization();
    }
    
    protected abstract void Initialization();

    public void OnDrop(PointerEventData eventData) 
    {
        if (!eventData.pointerDrag.TryGetComponent(out BaseItemUI droppedItemUI)) return;

        droppedItemUI.afterDragParent = transform;
        droppedItemUI.HandleDrop(gear);
    }

    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
}