using System;
using System.Collections.Generic;

public class EquipmentComponent : GearComponent
{
    private InventoryComponent inventory;
    private EquipmentManager equipmentManager;
    public event Action OnDefenceChanged
    {
        add => equipmentManager.OnDefenceChanged += value;
        remove => equipmentManager.OnDefenceChanged -= value;
    }

    public override void Initialize()
    {
        Storage = new GearStorage(maxSize);
        equipmentManager = new EquipmentManager(Storage);
        Manager = equipmentManager;

        base.Initialize();
    }

    public void Initialize(InventoryComponent inventoryComponent)
    {
        Initialize();
        
        inventory = inventoryComponent;
    }

    public bool CanEquipArmor(Item item, ArmorType armorType)
    {
        return equipmentManager.CanEquipArmor(item, armorType);
    }

    public override bool MoveItems(int fromIndex, int targetIndex)
    {
        return false;
    }

    public void Equip(Item currentItem)
    {
        equipmentManager.Equip(currentItem, inventory);
    }

    private void TryEquipItems(List<Item> items)
    {
        foreach (var item in items)
            Equip(item);
    }

    public void UnequipItem(Item currentItem)
    {
        equipmentManager.UnequipItem(currentItem);
    }
    
    public ArmorModel GetDefenceFlat()
    {
        return equipmentManager.GetDefenceFlat();
    }

    public override void AddItems(List<Item> items)
    {
        TryEquipItems(items);
    }

    public override void DropItem(int index) { }
}