using UnityEngine;

public class MeleeAttack : ItemAttack
{
    protected override void DealDamage()
    {
        if (itemContainer.ItemData is not WeaponData weaponData)
            return;
        
        if(!Raycaster.Cast(cam.position, cam.forward, weaponData.GetRange, out GameObject hitObject))
            return;
        
        Damageable damageable = hitObject.GetComponentInChildren<Damageable>();

        if (damageable != null)
            damageable.GetDamage(weaponData.GetDamage);
    }
}