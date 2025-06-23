using System;
using System.Collections.Generic;
using UnityEngine;

public class AttributeComponent : MonoBehaviour, ILoad
{
    [Header("Attribute List")]
    [SerializeField] private Attributes attributes;
    
    [Header("UI")]
    [SerializeField] private List<AttributeUI> attributeUIs;
    [SerializeField] private AttributeIncreaseUI attributeIncreaseUI;

    private LevelComponent level;

    public event Action<int> OnAttributeIncreased;
    
    public void Init(LevelComponent levelComponent)
    {
        level = levelComponent;
        attributes = new Attributes();

        InitUI();
    }

    private void InitUI()
    {
        foreach (var attributeUI in attributeUIs)
            attributeUI.Init(this);
        
        attributeIncreaseUI.Init(level);
    }

    public void LoadFromOrigin(Origin newOrigin)
    {
        attributes.LoadFromData(newOrigin.GetAttributesData);
    }

    public void LoadFromSave()
    {
        
    }

    public void SetAttribute(AttributeType attributeType, int value)
    {
        var attribute = GetAttribute(attributeType);
        
        if (attribute != null)
            attribute.Value = value;
    }
    
    public Attribute GetAttribute(AttributeType attributeType)
    {
        return attributeType switch
        {
            AttributeType.Strength => attributes.Strength,
            AttributeType.Constitution => attributes.Constitution,
            AttributeType.Dexterity => attributes.Dexterity,
            AttributeType.Perception => attributes.Perception,
            AttributeType.Intelligence => attributes.Intelligence,
            AttributeType.Wisdom => attributes.Wisdom,
            _ => null
        };
    }
    
    public void AttributeIncrease(AttributeType attributeType)
    {
        if (level.FreePoints == 0)
            return;
        
        Attribute attribute = GetAttribute(attributeType);
        attribute.Value += 1;
        
        OnAttributeIncreased?.Invoke(1);
    }
}

[Serializable]
public class Attributes
{
    [SerializeField] private Attribute strength = new(0);
    [SerializeField] private Attribute constitution = new(0);
    [SerializeField] private Attribute dexterity = new(0);
    [SerializeField] private Attribute perception = new(0);
    [SerializeField] private Attribute intelligence = new(0);
    [SerializeField] private Attribute wisdom = new(0);
    public Attribute Strength => strength;
    public Attribute Constitution => constitution;
    public Attribute Dexterity => dexterity;
    public Attribute Perception => perception;
    public Attribute Intelligence => intelligence;
    public Attribute Wisdom => wisdom;

    public void LoadFromData(AttributesData attributesData)
    {
        strength.Value = attributesData.Strength.Value;
        constitution.Value = attributesData.Constitution.Value;
        dexterity.Value = attributesData.Dexterity.Value;
        perception.Value = attributesData.Perception.Value;
        intelligence.Value = attributesData.Intelligence.Value;
        wisdom.Value = attributesData.Wisdom.Value;
    }
}