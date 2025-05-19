using UnityEngine.EventSystems;
public class HotbarSlotUI : SlotUI
{
    protected override void Initialization()
    {
        gear = GearSystems.Instance.Hotbar;
    }

    public override void OnPointerEnter(PointerEventData eventData) {}
    public override void OnPointerExit(PointerEventData eventData) {}
}