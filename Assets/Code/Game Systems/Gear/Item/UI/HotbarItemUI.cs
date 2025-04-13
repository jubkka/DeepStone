public class HotbarItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent gear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        if (slot.itemSlotType == ItemSlotType.Hotbar) 
        {
            int targetIndex = afterDragParent.GetSiblingIndex();

            gear.MoveItems(index, targetIndex);
        }
    }
}