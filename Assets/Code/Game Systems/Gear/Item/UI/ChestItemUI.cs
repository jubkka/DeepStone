public class ChestItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        switch (slot.itemSlotType)
        {
            case ItemSlotType.Chest:
                targetGear.MoveItems(index, targetIndex);
                break;
            case ItemSlotType.Inventory:
                HandleInventoryDrop(targetGear, targetIndex);
                break;
        }
    }

    private void HandleInventoryDrop(GearComponent inventory, int targetIndex)
    {
        if (inventory.IsFull()) 
            return;

        inventory.AddItem(item, targetIndex);
        gear.RemoveItem(index);
    }
}