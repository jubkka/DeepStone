using UnityEngine;
public abstract class ItemData : GenericElementData
{
    #region Fields
        [Header("Item Data")]
        [SerializeField] protected int weight;
        [SerializeField] protected int cost;
        [SerializeField] protected bool isLeftHanded = false;
    #endregion

    #region Properties
        public int GetWeight => weight;
        public int GetCost => cost;
        public bool IsLeftHanded => isLeftHanded;
    #endregion
    
    public override void TryEquip(HandEquipContext handEquipContext, Item item)
    {
        if (isLeftHanded)
            handEquipContext.LeftHand.PutInHand(item);
        else 
            handEquipContext.RightHand.PutInHand(item);
    }
}


