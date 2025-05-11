using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsageComponent : MonoBehaviour
{
    private Dictionary<(Type, ItemSlotType), Func<ElementData, IItemCommand>> commands = new();
    
    private EquipmentComponent equipment;
    private EffectComponent effectComponent;
    private HandComponent handComponent;
    private AttackComponent attackComponent;
    
    private void Start()
    { 
        equipment = GearSystems.Instance.GetEquipmentComponent;
        effectComponent = CharacterStatsSystems.Instance.GetEffectComponent;
        handComponent = CombatSystems.Instance.GetHandComponent;
        attackComponent = CombatSystems.Instance.GetAttackComponent;

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

    public IItemCommand GetCommandByContext(ItemSlotType type, ElementData data)
    {
        if (commands.TryGetValue((data.GetType(), type), out var factory))
            return factory(data);
        
        return null;
    }
}