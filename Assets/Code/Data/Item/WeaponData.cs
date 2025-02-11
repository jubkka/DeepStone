using UnityEngine;

[CreateAssetMenu(fileName = "TestWeapon", menuName = "Items/Weapons/TestWeapon")]
public class WeaponData : SimpleItemData, IEquippable
{
    [SerializeField] private int damage;
    public int GetDamage => damage;

    public void Equip()
    {
        Debug.Log($"Equiped weapon {nameItem}");
    }

    public override void Use()
    {
        Equip();
    }
}