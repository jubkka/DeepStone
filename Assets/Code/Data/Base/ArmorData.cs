using UnityEngine;

[CreateAssetMenu(fileName = "TestArmor", menuName = "Items/Armor/TestArmor")]
public class ArmorData : ItemData {
    [SerializeField] private string slotEquipment;
    public string GetSlotEquipment { get => slotEquipment; }
}