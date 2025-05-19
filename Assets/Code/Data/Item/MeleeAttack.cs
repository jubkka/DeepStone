using UnityEngine;

public class MeleeAttack : ItemAttack
{
    private WeaponData data;

    protected override void Start()
    {
        cam = Camera.main;
        data = (WeaponData)container.GetItem.data;
    }

    protected override void DealDamage()
    {
        if(!Raycaster.Cast(cam.transform.position, cam.transform.forward, data.GetRange, out GameObject hitObject))
            return;
        
        Damageable damageable = hitObject.GetComponentInChildren<Damageable>();

        if (damageable != null)
            damageable.GetDamage(data.GetDamage);
    }
}