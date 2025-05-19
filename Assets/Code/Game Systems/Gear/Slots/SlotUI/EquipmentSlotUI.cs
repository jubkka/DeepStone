using UnityEngine;

public class EquipmentSlotUI : TooltipSlotUI
{
    public ArmorType armorType;
    protected override void Initialization()
    {
        gear = GearSystems.Instance.Equipment;
    }
}