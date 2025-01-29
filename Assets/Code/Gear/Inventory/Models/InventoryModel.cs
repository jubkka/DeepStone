using UnityEngine;

public class InventoryModel : MonoBehaviour 
{
    public InventoryView view;
    public const int MaxInventorySize = 20;
    public ItemModel[] items = new ItemModel[MaxInventorySize];
}