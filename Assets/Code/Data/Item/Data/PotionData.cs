using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "TestPotion", menuName = "Items/Potions/TestPotion")]
public class PotionData : StackableItemData
{
    [SerializeField] private List<Effect> effects = new List<Effect>();

    public Effect AddEffect 
    {
        set => effects.Add(value);
    }

    public void Drink(EffectComponent effectComponent)
    {
        foreach (var effect in effects)
        {
            effectComponent.Apply(effect);
        }
    }

    public string CreateDescription()
    {
        var builder = new StringBuilder(description);
        
        foreach (var effect in effects)
        {
            builder.AppendLine(effect.GetDescription());
            builder.AppendLine();
        }

        return builder.ToString();
    }
}