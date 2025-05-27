using UnityEngine;
public abstract class ItemData : GenericElementData, IInfoDisplayable
{
    [Header("Item Data")]
    [SerializeField] protected int weight;
    [SerializeField] protected int cost;
    [SerializeField] protected bool isLeftHanded = false;

    public int GetWeight => weight;
    public int GetCost => cost;
    public bool IsLeftHanded => isLeftHanded;

    public string GetNameString => itemName;
    public string GetDescriptionString => description;
    public string GetCostString => $"<sprite name=\"coin\"> {cost}";
    public string GetWeightString => $"<sprite name=\"weight\"> {weight}";
    
    public override void TryEquip(HandEquipContext handEquipContext, Item item)
    {
        if (isLeftHanded)
            handEquipContext.LeftHand.PutInHand(item);
        else 
            handEquipContext.RightHand.PutInHand(item);
    }
}


