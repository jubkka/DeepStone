
using System.Linq;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] private InventoryModel inventoryModel;
    [SerializeField] private InventoryPresenter inventoryPresenter;
    [SerializeField] private StackabkeItemPresenter stackabkeItem;
    [SerializeField] private WearableItemObject wearableItem;
    [SerializeField] private SimpleItemPresenter simpleItem;
    public int count;
    public ItemData SimpleItemdata;
    public ItemData StackableItemdata;
    public ArmorData ArmorData;

    public void ShowInventory() 
    {
        var items = inventoryModel.items.Where(  
            state => state != null 
            )
            .ToList(); 

        foreach (var item in items)
        {
            Debug.Log($"ItemName: {item.data.GetName} " + $"Count: {item.count}");
        }
    }

    public void AddStackableItem() 
    {
        stackabkeItem.CreateItem(StackableItemdata, count);

        inventoryPresenter.AddItem(stackabkeItem.itemModel);
    }
    public void AddSimpleItem() 
    {
        simpleItem.CreateItem(SimpleItemdata, count);

        inventoryPresenter.AddItem(simpleItem.itemModel);
    }

    public void AddWearableItem() 
    {
        wearableItem.CreateItem(ArmorData, count);

        inventoryPresenter.AddItem(wearableItem.itemModel);
    }

    public void RemoveItem() 
    {
        Destroy(simpleItem.gameObject);
    }

    private void Log() {}

}