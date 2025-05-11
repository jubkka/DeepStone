using UnityEngine;

[CreateAssetMenu(fileName = "TestArmor", menuName = "Items/Armor/TestArmor")]
public class ArmorData : SimpleElementData
{
    [Header("Armor Data")]
    [SerializeField] private ArmorType armorType;
    [SerializeField] private int defense;
    
    public int GetDefense => defense;
    public ArmorType GetArmorType => armorType;
}