using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TestPotion", menuName = "Items/Potions/TestWeapon")]
public class PotionData : StackableElementData
{
    [SerializeField] private List<ItemEffectData> effects = new List<ItemEffectData>();

    public ItemEffectData AddEffect 
    {
        set => effects.Add(value);
    }

    public void Drink(EffectComponent effectComponent)
    {
        foreach (var effect in effects)
        {
            effect.Apply(effectComponent);
        }
    }
}