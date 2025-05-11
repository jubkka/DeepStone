using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : BaseItemUI
{
    [Header("Components")]
    [SerializeField] protected Image itemInHandIcon;

    private void Start()
    {
        CombatSystems.Instance.GetHandComponent.OnActiveItemChanged += ToggleItemInHandIcon;
        ToggleItemInHandIcon(CombatSystems.Instance.GetHandComponent.GetActiveItem);
    }

    private void OnDestroy()
    {
        CombatSystems.Instance.GetHandComponent.OnActiveItemChanged -= ToggleItemInHandIcon;
    }

    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        switch (slot.itemSlotType)
        {
            case ItemSlotType.Equipment:
                HandleEquipmentDrop(targetGear, slot);
                break;
            case ItemSlotType.Inventory:
                gear.MoveItems(index, targetIndex);
                break;
            case ItemSlotType.Hotbar:
                HandleHotbarDrop(targetGear, targetIndex);
                break;
            case ItemSlotType.Chest:
                HandleChestDrop(targetGear, targetIndex);
                break;
        }
    }
    private void HandleChestDrop(GearComponent targetGear, int targetIndex)
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

    private void HandleEquipmentDrop(GearComponent targetGear, SlotUI slot)
    {
        EquipmentComponent equipment = (EquipmentComponent)targetGear;
        EquipmentSlotUI equipmentSlotUI = (EquipmentSlotUI)slot;

        bool isEquip = equipment.CanEquipArmor(item, equipmentSlotUI.armorType);

        if (isEquip)
            equipment.Equip(gear.GetItem(index));
    }

    private void ToggleItemInHandIcon(Item itemInHand)
    {
        itemInHandIcon.enabled = itemInHand?.GetUniqueId == item.GetUniqueId;
    }

    protected override void Use()
    {
        item.Use(ItemSlotType.Inventory);
    }
}