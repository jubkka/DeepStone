using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/New Spell")]
public class SpellData : GenericElementData, ISpellBehavior
{
    [Header("Spell Data")]
    [SerializeField] protected int manaCost;
    [SerializeField] protected float cooldown;
    [SerializeField] private SpellBehaviorSO behavior;
    
    public int GetManaCost => manaCost;
    public float GetCooldown => cooldown;
    
    public void Cast(GameObject target)
    {
        behavior.Cast(target);
    }

    public override void TryEquip(HandEquipContext handEquipContext, Item item)
    {
        handEquipContext.MagicHand.PutInHand(item);
    }
}
