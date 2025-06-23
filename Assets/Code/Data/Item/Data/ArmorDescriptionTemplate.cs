using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ArmorTemplate", menuName = "Description Templates/Armor Template")]
public class ArmorDescriptionTemplate : ItemDescriptionTemplate
{
    [SerializeField] private string armorTypeColor = "#FF4444";
    [SerializeField] private string physicalDefColor = "#FF4444";
    [SerializeField] private string magicalDefColor = "#FF4444";

    protected override Dictionary<string, string> GetTemplateValues(IInfoDisplayable  ItemData)
    {
        var baseValues = base.GetTemplateValues(ItemData);

        if (ItemData is ArmorData armorData)
        {
            baseValues.Add("armorTypeColor", armorTypeColor);
            baseValues.Add("physicalDefColor", physicalDefColor);
            baseValues.Add("magicalDefColor", magicalDefColor);
            
            baseValues.Add("armorType", armorData.GetArmorType.ToString());
            baseValues.Add("physicalDef", armorData.GetPhysicalDef.ToString());
            baseValues.Add("magicalDef", armorData.GetMagicalDef.ToString());
        }
        
        return baseValues;
    }
}