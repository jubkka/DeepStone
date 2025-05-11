using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attribute
{
    [SerializeField] private int value;
    [SerializeField] private int baseValue;

    [SerializeField] private List<int> modifiers = new();
    
    public event Action<int> OnAttributeChanged;
    
    public int Value
    {
        get => value;
        set 
        {
            this.value = value;
            OnAttributeChanged?.Invoke(value);
        }
    }

    public List<int> GetModifiers() => modifiers;

    public int AddModifier
    {
        set => this.modifiers.Add(value);
    }

    public Attribute(int value)
    {
        this.value = value;
    }
}

public enum AttributeType
{
    Strength,
    Constitution,
    Dexterity,
    Perception,
    Intelligence,
    Wisdom,
}