using System;

public class SpellItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        switch (slot.itemSlotType)
        {
            case ItemSlotType.Spells:
                gear.MoveItems(index, targetIndex);
                break;
            case ItemSlotType.Hotbar:
                HandleHotbarDrop(targetGear, targetIndex);
                break;
        }
    }

    private void HandleHotbarDrop(GearComponent targetGear, int targetIndex)
    {
        if (targetGear.ContainsItem(item, out int existingIndex)) 
            targetGear.MoveItems(existingIndex, targetIndex);
    
        targetGear.AddItem(item, targetIndex);
    }
}