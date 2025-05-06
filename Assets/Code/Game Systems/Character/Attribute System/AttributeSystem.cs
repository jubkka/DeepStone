using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributeSystem
{
    [SerializeField] private List<Attribute> attributeList = new();

    private Dictionary<AttributeType, Attribute> attributes = new();
    
    public AttributeSystem(int str, int con, int dex, int per, int intel, int wis)
    {
        attributes[AttributeType.Strength] = new Attribute(str);
        attributes[AttributeType.Constitution] = new Attribute(con);
        attributes[AttributeType.Dexterity] = new Attribute(dex);
        attributes[AttributeType.Perception] = new Attribute(per);
        attributes[AttributeType.Intelligence] = new Attribute(intel);
        attributes[AttributeType.Wisdom] = new Attribute(wis);

        foreach (var attribute in attributes.Values)
            attributeList.Add(attribute);
    }

    public void SetAttribute(AttributeType type, int value)
    {
        attributes[type].Value = value;
    }

    public Attribute GetAttribute(AttributeType type)
    {
        return attributes[type];
    }

    public void SubscribeAttribute(AttributeType type, AttributeUI attributeUI)
    {
        attributes[type].OnAttributeChanged += attributeUI.UpdateValue;
    }
}