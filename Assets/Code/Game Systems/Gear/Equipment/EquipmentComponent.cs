using System;
using System.Collections.Generic;

public class EquipmentComponent : GearComponent
{
    private InventoryComponent inventory;

    public event Action OnDefenceChanged;
    
    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        Manager = new EquipmentManager(Storage);

        base.Initialize();
    }

    public void Initialize(InventoryComponent inventoryComponent)
    {
        Initialize();
        
        inventory = inventoryComponent;
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

    public void Equip(Item currentItem)
    {
        if(currentItem.data is not ArmorData armorData)
            return;

        int armorIndex = (int)armorData.GetArmorType;
        Item targetItem = GetItem(armorIndex);

        AddItem(new Item(currentItem.data, 1), armorIndex); // Добавляем текущий предмет в экипировку
        currentItem.Amount -= 1;

        if (targetItem.data != null)
            inventory.AddItem(targetItem, -1); // Добавляем старый предмет в инвентарь

        OnDefenceChanged?.Invoke();
    }

    private void TryEquipItems(List<Item> items)
    {
        foreach (var item in items)
            Equip(item);
    }

    public void UnequipItem(Item currentItem)
    {
        for (int i = 0; i < Storage.Items.Length; i++)
        {
            if (Storage.Items[i] == currentItem)
            {
                OnDefenceChanged?.Invoke();
                RemoveItem(i);
            }
        }
    }
    
    public ArmorModel GetDefenceFlat()
    {
        float physicalDef = 0;
        float magicalDef = 0;

        foreach (Item item in Storage.Items)
        {
            if (item.data is ArmorData data)
            {
                physicalDef += data.GetPhysicalDef;
                magicalDef += data.GetPhysicalDef;
            }
        }
        
        ArmorModel model = new(physicalDef, magicalDef);

        return model;
    }
    
    public ArmorModel GetDefencePercent() //Change on Percent
    {
        float physicalDef = 0;
        float magicalDef = 0;

        foreach (Item item in Storage.Items)
        {
            if (item.data is ArmorData data)
            {
                physicalDef += data.GetPhysicalDef;
                magicalDef += data.GetPhysicalDef;
            }
        }
        
        ArmorModel model = new(physicalDef, magicalDef);

        return model;
    }

    public override void AddItems(List<Item> items)
    {
        TryEquipItems(items);
    }

    public override void DropItem(int index) { }
}