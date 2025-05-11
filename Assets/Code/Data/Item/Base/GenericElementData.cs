using UnityEngine;

public class GenericElementData : ScriptableObject
{
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected string itemName;
    [TextArea] [SerializeField] protected string description;
    [SerializeField] protected Sprite icon;
    
    public GameObject GetPrefab => prefab;
    public string GetItemName => itemName;
    public string GetDescription => description;
    public Sprite GetIcon => icon;
}