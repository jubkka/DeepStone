using UnityEngine;

public class GenericElementData : ScriptableObject
{
    [Header("Generic Data")]
    [SerializeField] protected GameObject prefab;
    [SerializeField] protected string itemName;
    [TextArea] [SerializeField] protected string description;
    [SerializeField] protected string id;
    [SerializeField] protected Sprite icon;
    
    public GameObject GetPrefab => prefab;
    public string GetName => itemName;
    public string GetDescription => description;
    public Sprite GetIcon => icon;
    public string GetId => id;

    public virtual void TryEquip(HandEquipContext handEquipContext, Item item)
    {
        handEquipContext.RightHand.PutInHand(item);
    }
}