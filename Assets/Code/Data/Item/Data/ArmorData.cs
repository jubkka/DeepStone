using UnityEngine;

[CreateAssetMenu(fileName = "TestArmor", menuName = "Items/Armor/TestArmor")]
public class ArmorData : SimpleItemData
{
    [Header("Armor Data")]
    [SerializeField] private ArmorType armorType;
    [SerializeField] private float physicalDef;
    [SerializeField] private float magicalDef;
    
    public float GetPhysicalDef => physicalDef;
    public float GetMagicalDef => magicalDef;
    public ArmorType GetArmorType => armorType;
}