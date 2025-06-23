using UnityEngine;

[CreateAssetMenu(fileName = "TestWeapon", menuName = "Items/Weapons/TestWeapon")]
public class WeaponData : SimpleItemData, ICombatElement
{
    [Header("Weapon Data")]
    [SerializeField] private float damage;
    [SerializeField] [Range(0f, 1f)] private float criticalChance;
    [SerializeField] [Range(0f, 2f)] private float multiplierDamage;
    [SerializeField] private float range;
    [SerializeField] private GripType gripType;

    public float Damage
    {
        set => damage = value;
        get => damage;
    }
    
    public float GetCriticalChance => criticalChance;
    public float GetMultiplierDamage => multiplierDamage;
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