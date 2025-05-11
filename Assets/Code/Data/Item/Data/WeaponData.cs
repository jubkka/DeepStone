using UnityEngine;

[CreateAssetMenu(fileName = "TestWeapon", menuName = "Items/Weapons/TestWeapon")]
public class WeaponData : SimpleElementData
{
    [SerializeField] private int damage;
    [SerializeField] private float range;
    
    public int GetDamage => damage;
    public float GetRange => range;
}