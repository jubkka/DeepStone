using UnityEngine;

public class ChestItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        Debug.Log("Hi");

        switch (slot.slotType)
        {
            case SlotType.Chest:
                targetGear.MoveItems(index, targetIndex);
                break;
            case SlotType.Inventory:
                HandleInventoryDrop(targetGear, targetIndex);
                break;
        }
    }

    private void HandleInventoryDrop(GearComponent targetGear, int targetIndex)
    {
        if (targetGear.IsFull()) 
            return;

        targetGear.AddItem(item, targetIndex);
        gear.RemoveItem(index);
    }
}