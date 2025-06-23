using System;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/New Spell")]
public class SpellData : GenericElementData, ISpellBehavior, IInfoDisplayable
{
    [Header("Spell Data")]
    [SerializeField] protected int manaCost;
    [SerializeField] protected float cooldown;
    [SerializeField] private SpellBehavior behavior;

    public SpellBehavior Behavior
    {
        set => behavior = value;
        get => behavior;
    }
    
    public int GetManaCost => manaCost;
    public float GetCooldown => cooldown;
    
    public string GetNameString => itemName;
    public string GetDescriptionString => description;
    public string GetCostString => $"<sprite name=\"mana\"> {manaCost}";
    public string GetWeightString => String.Empty;

    public void Cast(GameObject target)
    {
        behavior.Cast(target);
    }

    public override void TryEquip(HandEquipContext handEquipContext, Item item)
    {
        handEquipContext.MagicHand.PutInHand(item);
    }
}
