using UnityEngine;

[CreateAssetMenu(fileName = "TestArmor", menuName = "Items/Armor/TestArmor")]
public class ArmorData : SimpleItemData, IEquippable {

    [Header("Armor Data")]
    [SerializeField] private ArmorType armorType;
    [SerializeField] private int defense;
    public int GetDefense => defense;
    public ArmorType GetArmorType => armorType;

    public void Equip() 
    {
        Debug.Log($"Equiped armor {nameItem}");
    }

    public override void Use()
    {
        Equip();
    }
}