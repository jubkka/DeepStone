using UnityEngine;
using Random = UnityEngine.Random;

public class MeleeAttack : ItemAttack
{
    private WeaponData weaponData;

    protected override GenericElementData Data
    {
        set => weaponData = Instantiate(value as WeaponData);
    }

    protected override void DealDamage()
    {
        SFXAudioManager.Instance.PlaySound("MeleeAttack");

        if(!Raycaster.Cast(cam.transform.position, cam.transform.forward, weaponData.GetRange, out GameObject hitObject))
            return;
        
        Damageable damageable = hitObject.GetComponentInChildren<Damageable>();

        if (damageable != null)
            damageable.GetDamage(weaponData.Damage);
    }

    protected override void CalculateDamage()
    {
        Attribute strength = attributeComponent.GetAttribute(attributeTypeImpactDamage);
        float criticalMultiplier = Random.value > weaponData.GetCriticalChance ? 2f : 1f;

        weaponData.Damage = (weaponData.Damage + (strength.Value * weaponData.GetMultiplierDamage)) * criticalMultiplier;
        
        attackView.UpdateText(Mathf.FloorToInt(weaponData.Damage));
    }
}