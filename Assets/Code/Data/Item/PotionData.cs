using UnityEngine;

[CreateAssetMenu(fileName = "TestPotion", menuName = "Items/Potions/TestWeapon")]
public class PotionData : StackableItemData
{
    public override void Use()
    {
        Debug.Log($"Drink potion {nameItem}");
    }
}