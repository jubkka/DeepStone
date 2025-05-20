using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Origin", menuName = "Player/Origin")]
public class Origin : ScriptableObject
{
    [SerializeField] private string nameOrigin;
    
    [Header("Indicators Values")]
    [SerializeField] private int health;
    [SerializeField] private int stamina;
    [SerializeField] private int mana;
    
    [Space(5)]
    [SerializeField] private AttributesData attributesData;
    [Space(5)]
    [SerializeField] private List<Item> items;
    [Space(5)]
    [SerializeField] private List<Item> spells;

    public string GetNameOrigin => nameOrigin;
    public int GetHealth => health;
    public int GetStamina => stamina;
    public int GetMana => mana;
    public AttributesData GetAttributesData => attributesData;
    public List<Item> GetItems => items;
    public List<Item> GetSpells => spells;
}
