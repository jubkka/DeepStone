using System;
using UnityEngine;

public class EquipmentManager : IGearManager
{
    private GearStorage storage;
    
    public event Action<int> OnItemChanged;
    public event Action<Item> OnItemAdded;
    public event Action<Item> OnItemRemoved;
    public event Action<Item> OnItemDropped;
    public event Action OnDefenceChanged;
    
    public EquipmentManager(GearStorage storage)
    {
        this.storage = storage;   
    }

    public bool AddItem(Item item, int index)
    {
        if (item == null) 
            return false;
        
        storage.SetItem(item, index);
        
        OnItemChanged?.Invoke(index);
        OnItemAdded?.Invoke(item);
        OnDefenceChanged?.Invoke();
        
        return true;
    }

    public bool RemoveItem(int index)
    {
        if (storage.Items[index] == null) 
            return false;
        
        OnItemRemoved?.Invoke(storage.Items[index]);
        
        storage.Items[index] = new Item();
        
        OnItemChanged?.Invoke(index);
        OnDefenceChanged?.Invoke();

        return true;
    }

    public bool DropItem(int index)
    {
        return false;
    }

    public bool MoveItems(int fromIndex, int targetIndex) { return false;}
    
    public bool CanEquipArmor(Item item, ArmorType armorType) 
    {
        if (item.data is ArmorData armor)
            return armor.GetArmorType == armorType;

        Debug.Log($"This item {item.data.name} not armor");
        return false;
    }
    
    public bool Equip(Item currentItem, InventoryComponent inventory)
    {
        if (currentItem.data is not ArmorData armorData)
        {
            Debug.Log($"This armor {currentItem.data.name} is not an armor");
            return false;
        }

        int armorIndex = (int)armorData.GetArmorType;
        Item targetItem = storage.GetItem(armorIndex);

        AddItem(new Item(currentItem.data, 1), armorIndex); // Добавляем текущий предмет в экипировку
        currentItem.Amount -= 1;

        if (targetItem.data != null)
            inventory.AddItem(targetItem, -1); // Добавляем старый предмет в инвентарь
        
        Debug.Log($"{armorData.name} is equipped {armorData.GetArmorType}");
        return true;
    }

    public void UnequipItem(Item currentItem)
    {
        for (int i = 0; i < storage.Items.Length; i++)
        {
            if (storage.Items[i] == currentItem)
            {
                OnItemDropped?.Invoke(storage.Items[i]);
                RemoveItem(i);
            }
        }
    }
    
    public ArmorModel GetDefenceFlat()
    {
        float physicalDef = 0;
        float magicalDef = 0;

        foreach (Item item in storage.Items)
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
}