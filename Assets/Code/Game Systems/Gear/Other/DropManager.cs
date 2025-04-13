using System;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public event Action<Item> OnItemDropped;
    
    private void Start()
    {
        InventoryComponent inventory = GameSystems.Instance.GetInventoryComponent;
        inventory.OnItemRemoved += Drop;
    }

    public void Drop(Item item) 
    {
        SpawnItem(item.data, item.Amount);
        
        OnItemDropped?.Invoke(new Item());
    }

    private void SpawnItem(ItemData itemData, int amount)
    {
        GameObject newitem = Instantiate(itemData.GetPrefab, transform.position, new Quaternion());
        ItemContainer container = newitem.GetComponentInChildren<ItemContainer>();
        
        container.ItemData = itemData;
        container.Amount = amount;

        CorrectTransform(newitem);
    }

    private void CorrectTransform(GameObject item)
    {
        CorrectTransform correctTransform = item.GetComponentInChildren<CorrectTransform>();
        correctTransform?.Setup();
    }
}