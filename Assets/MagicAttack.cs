using UnityEngine;

public class MagicAttack : ItemAttack
{
    [SerializeField] private GameObject projectile;
    
    private SpellData spellData;
    private DamageSpellData spellBehavior;

    protected override GenericElementData Data
    {
        set
        {
            spellData = Instantiate(value as SpellData);
            spellBehavior = Instantiate(spellData.Behavior as DamageSpellData);
            
            spellData.Behavior = spellBehavior;
        }
    }

    protected override void DealDamage()
    {
        GameObject newProjectile = Instantiate(projectile, cam.transform.position, Quaternion.identity);
        LauncherProjectile launcherProjectile = newProjectile.GetComponentInChildren<LauncherProjectile>();
        
        launcherProjectile.Data = spellData;
        launcherProjectile?.Init(cam.transform);
        
        CombatSystems.Instance.Indicator.Cast(spellData.GetManaCost);
    }

    protected override void CalculateDamage()
    {
        Attribute intelligence = attributeComponent.GetAttribute(attributeTypeImpactDamage);
        float criticalMultiplier = Random.value > spellBehavior.CriticalChance ? 2f : 1f;

        spellBehavior.Damage = (spellBehavior.Damage + (intelligence.Value * spellBehavior.MultiplierDamage)) * criticalMultiplier;
        
        attackView.UpdateText(Mathf.FloorToInt(spellBehavior.Damage));
    }
}
