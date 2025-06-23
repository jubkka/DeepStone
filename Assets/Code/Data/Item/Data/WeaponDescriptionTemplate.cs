using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="WeaponTemplate", menuName = "Description Templates/Weapon Template")]
public class WeaponDescriptionTemplate : ItemDescriptionTemplate
{
    [SerializeField] private string damageColor = "#FF4444";
    [SerializeField] private string criticalChanceColor = "#FF4444";
    [SerializeField] private string multiplierDamageColor = "#FF4444";
    [SerializeField] private string gripTypeColor = "#FF4444";

    protected override Dictionary<string, string> GetTemplateValues(IInfoDisplayable  ItemData)
    {
        var baseValues = base.GetTemplateValues(ItemData);

        if (ItemData is WeaponData weaponData)
        {
            baseValues.Add("damageColor", damageColor);
            baseValues.Add("criticalChanceColor", criticalChanceColor);
            baseValues.Add("multiplierDamageColor", multiplierDamageColor);
            baseValues.Add("gripTypeColor", gripTypeColor);
            
            baseValues.Add("damage", weaponData.Damage.ToString());
            baseValues.Add("criticalChance", weaponData.GetCriticalChance.ToString());
            baseValues.Add("multiplierDamage", weaponData.GetMultiplierDamage.ToString());
            baseValues.Add("gripType", weaponData.GetGripType.ToString());
        }
        
        return baseValues;
    }
}