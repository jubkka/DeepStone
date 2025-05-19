using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Spell", menuName = "Spells/Behaviors/DamageSpell")]
public class DamageSpellData : SpellBehaviorSO, ICombatElement
{
    [SerializeField] private int damage;
    public GripType GetGripType { get; }
    
    public float GetDamage => damage;
    
    public override void Cast(GameObject target)
    {
        Damageable damageable = target.GetComponentInChildren<Damageable>();
        
        if (damageable != null)
            damageable.GetDamage(damage);
    }
}