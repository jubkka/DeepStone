public class InventoryItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent gear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        if (slot.slotType == SlotType.Inventory) 
        {
            gear.MoveItems(index, targetIndex);
        } 
        else if (slot.slotType == SlotType.Equipment) 
        {
            gear.AddItem(item, targetIndex);
            this.gear.RemoveItem(index);
        }
        else if (slot.slotType == SlotType.Hotbar) 
        {
            if (gear.ContainsItem(item, out int existingIndex)) gear.MoveItems(existingIndex, targetIndex);
            
            gear.AddItem(item, targetIndex);
        }
    }
}