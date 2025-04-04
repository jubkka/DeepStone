using System;
using System.Collections.Generic;

public class ItemUsageSystem
{
    private Dictionary<(Type, ItemSlotType), Func<ItemData, IItemCommand>> commands = new();
    
    private EquipmentComponent equipment;
    private EffectComponent effectComponent;
    private HandComponent handComponent;
    private AttackComponent attackComponent;
    
    public ItemUsageSystem(
        EquipmentComponent equipment, EffectComponent effectComponent, 
        HandComponent handComponent, AttackComponent attackComponent
        ) 
    { 
        this.equipment = equipment;
        this.effectComponent = effectComponent;
        this.handComponent = handComponent;
        this.attackComponent = attackComponent;

        AddCommands();
    }

    private void AddCommands()
    {
        commands.Add((typeof(ArmorData), ItemSlotType.Inventory), data => new EquipCommand(equipment));
        commands.Add((typeof(PotionData), ItemSlotType.Inventory), data => new DrinkCommand(effectComponent));
        commands.Add((typeof(PotionData), ItemSlotType.Hotbar), data => new DrinkCommand(effectComponent));
        commands.Add((typeof(WeaponData), ItemSlotType.Inventory), data => new TakeCommand(handComponent));
        commands.Add((typeof(WeaponData), ItemSlotType.Hotbar), data => new AttackCommand(attackComponent));
    }

    public IItemCommand GetCommandByContext(ItemSlotType type, ItemData data)
    {
        if (commands.TryGetValue((data.GetType(), type), out var factory))
            return factory(data);
        
        return null;
    }
}