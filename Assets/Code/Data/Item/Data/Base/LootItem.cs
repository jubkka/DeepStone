using UnityEngine;

[System.Serializable]
public class LootItem
{
    public ItemData data;
    [Range(0, 1000)] public float weight;
}