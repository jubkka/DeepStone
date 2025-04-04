using UnityEngine;
using UnityEngine.Serialization;

public class EquipCommand : IItemCommand
{
    private EquipmentComponent equipment;
    
    public EquipCommand(EquipmentComponent equipment)
    {
        this.equipment = equipment;
    }

    public void Execute(Item item)
    {
        if(item.data is not ArmorData armorData)
            return;
        
        equipment.Equip(item, (int)armorData.GetArmorType);
    }
}