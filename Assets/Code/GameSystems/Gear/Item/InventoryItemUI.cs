using System;
using Unity.Burst;

public class InventoryItemUI : BaseItemUI
{
    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        switch (slot.slotType)
        {
            case SlotType.Equipment:
                HandleEquipmentDrop(targetGear, targetIndex, slot);
                break;
            case SlotType.Inventory:
                targetGear.MoveItems(index, targetIndex);
                break;
            case SlotType.Hotbar:
                HandleHotbarDrop(targetGear, targetIndex);
                break;
            case SlotType.Chest:
                HandleChestrDrop(targetGear, targetIndex);
                break;
        }
    }
    private void HandleChestrDrop(GearComponent targetGear, int targetIndex)
    {
        if (targetGear.IsFull())
            return;

        targetGear.AddItem(item, targetIndex);
        gear.RemoveItem(index);
    }

    private void HandleHotbarDrop(GearComponent targetGear, int targetIndex)
    {
        if (targetGear.ContainsItem(item, out int existingIndex)) 
        targetGear.MoveItems(existingIndex, targetIndex);
    
        targetGear.AddItem(item, targetIndex);
    }
    //Костыльный метод, но по другому не знаю как сделать, будущий я разберется.
    private void HandleEquipmentDrop(GearComponent targetGear, int targetIndex, SlotUI slot)
    {
        if (!CanEquipArmor((EquipmentSlotUI)slot)) return;

        Item currentItem = item;
        Item targetItem  = targetGear.GetItem(targetIndex);

        if (targetItem.data == null) //Если слот в экипировке пустой
        {
            targetGear.AddItem(currentItem, targetIndex); // Добавляем предмет в экипировку
            gear.RemoveItem(index); //Удаляем из инвентаря
        }
        else 
        {
            targetGear.RemoveItem(targetIndex); // Удаляем предмет в слоте экипировки
            targetGear.AddItem(currentItem, targetIndex); // Добавляем предмет из инвентаря
            gear.RemoveItem(index);  // Удаляем предмет из инвентаря
            gear.AddItem(targetItem, index); // Добавляем предмет из экипировки в инвентарь
        }
    }
    private bool CanEquipArmor(EquipmentSlotUI slot) 
    {
        if (item.data is ArmorData armor) 
        {
            return armor.GetArmorType == slot.armorType;
        }

        return false;
    }
}