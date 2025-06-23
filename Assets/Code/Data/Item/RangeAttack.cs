using UnityEngine;

public class RangeAttack : ItemAttack
{
    [SerializeField] private GameObject projectile;

    private WeaponData weaponData;

    protected override GenericElementData Data
    {
        set => weaponData = Instantiate(value as WeaponData);
    }

    protected override void DealDamage()
    {
        SFXAudioManager.Instance.PlaySound("RangeAttack");
        
        GameObject newProjectile = Instantiate(projectile, cam.transform.position, Quaternion.identity);
        LauncherProjectile launcherProjectile = newProjectile.GetComponentInChildren<LauncherProjectile>();
        
        launcherProjectile.Data = weaponData;
        launcherProjectile?.Init(cam.transform);
    }

    protected override void CalculateDamage()
    {
        Attribute dexterity = attributeComponent.GetAttribute(attributeTypeImpactDamage);
        float criticalMultiplier = Random.value > weaponData.GetCriticalChance ? 2f : 1f;

        weaponData.Damage = (weaponData.Damage + (dexterity.Value * weaponData.GetMultiplierDamage)) * criticalMultiplier;
        
        attackView.UpdateText(Mathf.FloorToInt(weaponData.Damage));
    }
}