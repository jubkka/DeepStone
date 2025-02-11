public class EquipmentItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        if (slot.slotType == SlotType.Inventory) 
        {
            targetGear.AddItem(item, targetIndex);
            gear.RemoveItem(index);
        } 
    }

}