using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipSlotUI : SlotUI
{
    [Header("Decoration")]
    [SerializeField] protected ItemInfoPanel itemInfoPanel;
    [SerializeField] protected SlotHoverHandler activeSlot;

    public override void OnPointerEnter(PointerEventData eventData) 
    {
        Transform slot = transform.parent;
        int indexSlot = transform.GetSiblingIndex();

        itemInfoPanel.ToggleItemInfo(gear, indexSlot);
        activeSlot.MoveActiveSlot(slot, indexSlot);
    }
    public override void OnPointerExit(PointerEventData eventData) 
    {
        itemInfoPanel.DoFadePanel(0f);
        activeSlot.HideActiveSlot();
    }
}