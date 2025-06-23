using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Spell", menuName = "Spells/Behaviors/DamageSpell")]
public class DamageSpellData : SpellBehavior, ICombatElement
{
    [SerializeField] private float damage;
    [SerializeField] private float criticalChance;
    [SerializeField] private float multiplierDamage;
    
    [SerializeField] private float multiplierCriticalChance;
    
    public GripType GetGripType { get; }
    public float Damage
    {
        get => damage;
        set => damage = value;
    }
    
    public float CriticalChance => criticalChance;
    public float MultiplierDamage => multiplierDamage;

    public override void Cast(GameObject target)
    {
        Damageable damageable = target.GetComponentInChildren<Damageable>();
        
        if (damageable != null)
            damageable.GetDamage(damage);
    }

    public override void CreateDescription()
    {
        
    }
}