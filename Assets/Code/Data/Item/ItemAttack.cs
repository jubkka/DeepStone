using UnityEngine;

public class ItemAttack : MonoBehaviour
{
    private Transform cam;
    private ItemContainer itemContainer;

    private void Start()
    {
        cam = Camera.main.transform;
        itemContainer = GetComponentInChildren<ItemContainer>();
    }

    public void DealDamage()
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