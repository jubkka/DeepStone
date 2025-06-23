using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "TemplateManager", menuName = "Description Templates/Template Manager")]
public class ItemTemplateManager : ScriptableObject
{
    [Header("Шаблоны по типам предметов")]
    public WeaponDescriptionTemplate weaponTemplate;
    public ArmorDescriptionTemplate armorTemplate;
    public SpellDescriptionTemplate spellTemplate;
    public PotionDescriptionTemplate potionTemplate;
    public ItemDescriptionTemplate defaultTemplate;
    
    public (string name, string weight, string cost, string description, TextAlignmentOptions alignment) GetFormattedDescription(IInfoDisplayable  itemData)
    {
        var template = GetTemplateForItem(itemData);
        
        var nameData = template.GenerateName(itemData);
        var weight = template.GenerateWeight(itemData);
        var cost = template.GenerateCost(itemData);
        var description = template.GenerateDescription(itemData);
        
        return (nameData, weight, cost, description, template.GetTextAlignment);
    }
    
    private ItemDescriptionTemplate GetTemplateForItem(IInfoDisplayable  itemData)
    {
        return itemData switch
        {
            WeaponData => weaponTemplate,
            PotionData => potionTemplate,
            ArmorData => armorTemplate,
            SpellData => spellTemplate,
            _ => defaultTemplate
        };
    }
}