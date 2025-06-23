public class EquipmentItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent inventory)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        if (slot.itemSlotType == ItemSlotType.Inventory) 
        {
            if (inventory.IsFull) 
                return;

            inventory.AddItem(item, targetIndex);
            gear.RemoveItem(index);
        } 
        
        PlacedItemSound();
    }
    
    protected override void Use()
    {
        item.Use(ItemSlotType.Equipment);
    }
}