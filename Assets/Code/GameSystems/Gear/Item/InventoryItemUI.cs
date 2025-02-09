public class InventoryItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent hotbar)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        if (slot.slotType == SlotType.Inventory) 
        {
            int targetIndex = afterDragParent.GetSiblingIndex();

            gear.MoveItems(index, targetIndex);
        } 
        else if (slot.slotType == SlotType.Hotbar) 
        {
            int targetIndex = afterDragParent.GetSiblingIndex();

            if (hotbar.ContainsItem(item, out int existingIndex)) hotbar.MoveItems(existingIndex, targetIndex);
            
            hotbar.AddItem(item, targetIndex);
        }
    }
}