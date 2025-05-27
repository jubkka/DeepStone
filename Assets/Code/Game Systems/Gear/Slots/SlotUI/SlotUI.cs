using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IDropHandler
{
    [Header("Services")]
    [SerializeField] protected GearComponent gear;
    public ItemSlotType itemSlotType;
    
    public void OnDrop(PointerEventData eventData) 
    {
        if (!eventData.pointerDrag.TryGetComponent(out BaseItemUI droppedItemUI)) return;

        droppedItemUI.afterDragParent = transform;
        droppedItemUI.HandleDrop(gear);
    }

    public abstract void OnPointerEnter(PointerEventData eventData);
    public abstract void OnPointerExit(PointerEventData eventData);
}