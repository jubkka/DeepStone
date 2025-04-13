using UnityEngine.EventSystems;
public class HotbarSlotUI : SlotUI
{
    protected override void Initialization()
    {
        gear = GameSystems.Instance.GetHotbarComponent;
    }

    public override void OnPointerEnter(PointerEventData eventData) {}
    public override void OnPointerExit(PointerEventData eventData) {}
}