using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsageSystem
{
    private readonly Dictionary<(Type, ItemSlotType), Func<GenericElementData, IItemCommand>> commands = new();
    
    private readonly InventoryComponent inventory;
    private readonly EquipmentComponent equipment;
    private readonly EffectComponent effectComponent;
    private readonly AttackComponent attackComponent;
    private readonly SpellCastingComponent spellCastingComponent;
    
    public ItemUsageSystem()
    {
        inventory = GearSystems.Instance.Inventory;
        equipment = GearSystems.Instance.Equipment;
        effectComponent = CharacterStatsSystems.Instance.Effect;
        //handComponent = CombatSystems.Instance.GetHandComponent;
        attackComponent = CombatSystems.Instance.GetAttackComponent;
        spellCastingComponent = CombatSystems.Instance.GetSpell;

        AddCommands();
    }

    private void AddCommands()
    {
        commands.Add((typeof(ArmorData), ItemSlotType.Inventory), _ => new EquipCommand(equipment));
        commands.Add((typeof(PotionData), ItemSlotType.Inventory), _ => new DrinkCommand(effectComponent));
        //commands.Add((typeof(WeaponData), ItemSlotType.Inventory), _ => new TakeCommand(handComponent));
        
        commands.Add((typeof(ArmorData), ItemSlotType.Equipment), _ => new UnequipCommand(equipment, inventory));
        
        commands.Add((typeof(PotionData), ItemSlotType.Hotbar), _ => new DrinkCommand(effectComponent));
        commands.Add((typeof(WeaponData), ItemSlotType.Hotbar), _ => new AttackCommand(attackComponent));
        commands.Add((typeof(SpellData), ItemSlotType.Hotbar), _ => new SpellCastingCommand(spellCastingComponent));
    }

    public IItemCommand GetCommandByContext(ItemSlotType type, GenericElementData data)
    {
        if (commands.TryGetValue((data.GetType(), type), out var factory))
            return factory(data);
        
        return null;
    }
}