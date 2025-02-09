public class HotbarItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent inventory)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        if (slot.slotType == SlotType.Inventory)
        {
            return;
        }
        else if (slot.slotType == SlotType.Hotbar) 
        {
            int targetIndex = afterDragParent.GetSiblingIndex();

            gear.MoveItems(index, targetIndex);
        }
    }
}