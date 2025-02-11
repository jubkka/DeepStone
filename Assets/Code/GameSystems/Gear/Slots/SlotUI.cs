using UnityEngine;
using UnityEngine.EventSystems;

public class SlotUI : MonoBehaviour, IDropHandler
{
    public GearComponent gear;
    public SlotType slotType;
    public ArmorType armorType;

    public virtual void OnDrop(PointerEventData eventData) 
    {
        if (!eventData.pointerDrag.TryGetComponent(out BaseItemUI droppedItemUI)) return;

        droppedItemUI.afterDragParent = transform;
        droppedItemUI.HandleDrop(gear);
    }
}