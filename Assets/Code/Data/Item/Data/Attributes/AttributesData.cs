using UnityEngine;

[CreateAssetMenu(fileName = "New Attributes", menuName = "Player/Attributes")]
public class AttributesData : ScriptableObject
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
    
    public Attribute GetAttribute(AttributeType attributeType)
    {
        return attributeType switch
        {
            AttributeType.Strength => strength,
            AttributeType.Constitution => constitution,
            AttributeType.Dexterity => dexterity,
            AttributeType.Perception => perception,
            AttributeType.Intelligence => intelligence,
            AttributeType.Wisdom => wisdom,
            _ => null
        };
    }
}