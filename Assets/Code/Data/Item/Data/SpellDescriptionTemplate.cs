using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="SpellTemplate", menuName = "Description Templates/Spell Template")]
public class SpellDescriptionTemplate : ItemDescriptionTemplate
{
    [SerializeField] private string cooldownColor = "#FF4444";
    [SerializeField] private string costColor = "#FF4444";
    
    [SerializeField] private string damageColor = "#FF4444";
    [SerializeField] private string criticalChanceColor = "#FF4444";
    [SerializeField] private string multiplierDamageColor = "#FF4444";

    [SerializeField] [TextArea(10, 20)] private string effectDescription;
     
    protected override Dictionary<string, string> GetTemplateValues(IInfoDisplayable  ItemData)
    {
        var baseValues = base.GetTemplateValues(ItemData);

        if (ItemData is SpellData spellData)
        {
            baseValues.Add("cooldownColor", cooldownColor);
            baseValues.Add("costColor", costColor);
            
            baseValues.Add("cooldown", spellData.GetCooldown.ToString());
            baseValues["cost"] = spellData.GetCostString;

            AddEffectToDescription(spellData, baseValues);
        }
        
        return baseValues;
    }

    private void AddEffectToDescription(SpellData spellData, Dictionary<string, string> values)
    {
        if (spellData.Behavior is DamageSpellData damageSpellData)
        {
            values.Add("damageColor", damageColor);
            values.Add("criticalChanceColor", criticalChanceColor);
            values.Add("multiplierDamageColor", multiplierDamageColor);
            
            values.Add("damage", damageSpellData.Damage.ToString());
            values.Add("multiplierDamage", damageSpellData.MultiplierDamage.ToString());
            values.Add("criticalChance", damageSpellData.CriticalChance.ToString());

            string filledEffect = ApplyCustomTemplate(effectDescription, values);
            values["effect"] = filledEffect;
        }

        if (spellData.Behavior is EffectSpellData)
            return;
    }
}