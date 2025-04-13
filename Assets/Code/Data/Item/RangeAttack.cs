using UnityEngine;

public class RangeAttack : ItemAttack
{
    [SerializeField] private GameObject arrow;
    
    protected override void DealDamage()
    {
        if (itemContainer.ItemData is not WeaponData)
            return;
        
        Instantiate(arrow, cam.position, Quaternion.identity);
    }
}