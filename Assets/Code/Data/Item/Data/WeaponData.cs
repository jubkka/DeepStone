using UnityEngine;

[CreateAssetMenu(fileName = "TestWeapon", menuName = "Items/Weapons/TestWeapon")]
public class WeaponData : SimpleItemData, ICombatElement
{
    [Header("Weapon Data")]
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private GripType gripType;

    public float GetDamage => damage;
    public float GetRange => range;
    public GripType GetGripType => gripType;
    
    public override void TryEquip(HandEquipContext handEquipContext, Item item)
    {
        if (gripType == GripType.TwoHanded)
            handEquipContext.LeftHand.ClearHand();
        
        handEquipContext.RightHand.PutInHand(item);
    }
}

public enum GripType
{
    None,
    OneHanded,
    TwoHanded,
    Magic
}