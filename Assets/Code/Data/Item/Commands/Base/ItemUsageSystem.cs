using System;
using System.Collections.Generic;

public class ItemUsageSystem
{
    private Dictionary<(Type, ItemSlotType), Func<ItemData, IItemCommand>> commands = new();
    
    private EquipmentComponent equipment;
    private EffectComponent effectComponent;
    private HandComponent handComponent;
    
    public ItemUsageSystem(EquipmentComponent equipment, EffectComponent effectComponent, HandComponent handComponent)
    { 
        this.equipment = equipment;
        this.effectComponent = effectComponent;
        this.handComponent = handComponent;

        AddCommands();
    }

    private void AddCommands()
    {
        commands.Add((typeof(ArmorData), ItemSlotType.Inventory), data => new EquipCommand(equipment));
        commands.Add((typeof(PotionData), ItemSlotType.Inventory), data => new DrinkCommand(effectComponent));
        commands.Add((typeof(PotionData), ItemSlotType.Hotbar), data => new DrinkCommand(effectComponent));
        commands.Add((typeof(WeaponData), ItemSlotType.Inventory), data => new TakeCommand(handComponent));
    }

    public IItemCommand GetCommandByContext(ItemSlotType type, ItemData data)
    {
        if (commands.TryGetValue((data.GetType(), type), out var factory))
            return factory(data);
        
        return null;
    }
}