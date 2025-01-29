using UnityEngine;

public abstract class ItemPresenter : MonoBehaviour
{
    public ItemModel itemModel;
    public int count; 
    public abstract void CreateItem(ItemData data, int count = 1);
}
