using System;
using UnityEngine;

public class AttributeComponent : MonoBehaviour
{
    [SerializeField] private Attributes attributes;
    
    private LevelComponent levelComponent;

    public void Init(Origin newOrigin)
    {
        levelComponent = CharacterStatsSystems.Instance.LevelComponent;
        attributes = new Attributes(newOrigin.GetAttributesData);
    }
    
    public void SetAttribute(AttributeType attributeType, int value)
    {
        var attribute = GetAttribute(attributeType);
        
        if (attribute != null)
            attribute.Value = value;
    }
    
    private Attribute GetAttribute(AttributeType attributeType)
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
        if (levelComponent.CountFreePoints == 0)
            return;
        
        Attribute attribute = GetAttribute(attributeType);
        attribute.Value += 1;
        
        levelComponent.CountFreePoints -= 1;
    }
    
    public void SubscribeAttribute(AttributeType attributeType, AttributeUI attributeUI)
    {
        var attribute = GetAttribute(attributeType);

        if (attribute != null)
        {
            attribute.OnAttributeChanged += attributeUI.UpdateValue;
            attributeUI.UpdateValue(attribute.Value);
        }
    }
}

[Serializable]
public class Attributes
{
    [SerializeField] private Attribute strength;
    [SerializeField] private Attribute constitution;
    [SerializeField] private Attribute dexterity;
    [SerializeField] private Attribute perception;
    [SerializeField] private Attribute intelligence;
    [SerializeField] private Attribute wisdom;
    public Attribute Strength => strength;
    public Attribute Constitution => constitution;
    public Attribute Dexterity => dexterity;
    public Attribute Perception => perception;
    public Attribute Intelligence => intelligence;
    public Attribute Wisdom => wisdom;
    
    public Attributes(AttributesData attributesData)
    {
        strength = new Attribute(attributesData.Strength.Value);
        constitution = new Attribute(attributesData.Constitution.Value);
        dexterity = new Attribute(attributesData.Dexterity.Value);
        perception = new Attribute(attributesData.Perception.Value);
        intelligence = new Attribute(attributesData.Intelligence.Value);
        wisdom = new Attribute(attributesData.Wisdom.Value);
    }
}