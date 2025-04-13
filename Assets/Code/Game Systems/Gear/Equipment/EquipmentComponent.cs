using System;
using UnityEngine;

public class EquipmentComponent : GearComponent
{
    private InventoryComponent inventory;
    
    protected override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        Manager = new EquipmentManager(Storage);

        base.Initialize();
    }
    protected override void PostInitialize()
    {
        base.PostInitialize();

        inventory = GameSystems.Instance.GetInventoryComponent;
    }

    public bool CanEquipArmor(Item item, ArmorType armorType) 
    {
        if (item.data is ArmorData armor) 
            return armor.GetArmorType == armorType;

        return false;
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return false;
    }

    public void Equip(Item currentItem, int targetIndex)
    {
        Item targetItem = GetItem(targetIndex);

        AddItem(new Item(currentItem.data, 1), targetIndex); // Добавляем текущий предмет в экипировку
        currentItem.Amount -= 1;

        if (targetItem.data != null)
            inventory.AddItem(targetItem, -1); // Добавляем старый предмет в инвентарь
    }
}