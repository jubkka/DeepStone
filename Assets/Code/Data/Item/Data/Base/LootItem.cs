using UnityEngine;

[System.Serializable]
public class LootItem
{
    public ElementData data;
    [Range(0, 1000)] public float weight;
}