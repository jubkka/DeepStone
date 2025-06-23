using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName="DefaultTemplate", menuName = "Description Templates/Default Template")]
public class ItemDescriptionTemplate : ScriptableObject
{
    [Header("Настройка шаблона")]
    [SerializeField] protected TextAlignmentOptions textAlignment = TextAlignmentOptions.Left;

    [Header("Шаблоны")]
    [SerializeField] protected string nameTemplate = "<color=#FFD700>{name}</color>";
    [SerializeField] private string costTemplate = "{cost}";
    [SerializeField] private string weightTemplate = "{weight}";
    
    [Header("Шаблон описания RichText")] 
    [TextArea(10, 20)] [SerializeField] protected string template;

    public virtual string GenerateDescription(IInfoDisplayable item)
    {
        var values = GetTemplateValues(item);
        return ApplyTemplate(values);
    }

    public virtual string GenerateName(IInfoDisplayable item)
    {
        var values = GetTemplateValues(item);
        return ApplyCustomTemplate(nameTemplate, values);
    }

    public virtual string GenerateCost(IInfoDisplayable item)
    {
        var values = GetTemplateValues(item);
        return ApplyCustomTemplate(costTemplate, values);
    }

    public virtual string GenerateWeight(IInfoDisplayable item)
    {
        var values = GetTemplateValues(item);
        return ApplyCustomTemplate(weightTemplate, values);
    }
    
    public TextAlignmentOptions GetTextAlignment => textAlignment;

    protected virtual Dictionary<string, string> GetTemplateValues(IInfoDisplayable itemData)
    {
        return new Dictionary<string, string>
        {
            { "name", itemData.GetNameString },
            { "cost", itemData.GetCostString },
            { "weight", itemData.GetWeightString },
        };
    }
    
    protected string ApplyTemplate(Dictionary<string, string> values)
    {
        string result = template;
        foreach (var pair in values)
        {
            result = result.Replace($"{{{pair.Key}}}", pair.Value);
        }
        return result;
    }
    
    protected string ApplyCustomTemplate(string templateStr, Dictionary<string, string> values)
    {
        string result = templateStr;
        foreach (var pair in values)
        {
            result = result.Replace($"{{{pair.Key}}}", pair.Value);
        }
        return result;
    }
}