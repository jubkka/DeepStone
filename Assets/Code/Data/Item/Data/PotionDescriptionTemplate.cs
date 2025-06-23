using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PotionTemplate", menuName = "Description Templates/Potion Template")]
public class PotionDescriptionTemplate : ItemDescriptionTemplate
{
    protected override Dictionary<string, string> GetTemplateValues(IInfoDisplayable itemData)
    {
        var baseValues = base.GetTemplateValues(itemData);

        if (itemData is PotionData potionData)
        {
            baseValues.Add("effects", potionData.CreateDescription());
        }
        
        return baseValues;
    }
}