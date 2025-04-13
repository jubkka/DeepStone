using UnityEngine;

public class EquipmentSlotUI : TooltipSlotUI
{
    public ArmorType armorType;
    protected override void Initialization()
    {
        gear = GameSystems.Instance.GetEquipmentComponent;
    }
}