using System;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    public event Action<Item> OnItemDropped;
    
    private void Start()
    {
        InventoryComponent inventory = GearSystems.Instance.GetInventoryComponent;
        inventory.OnItemRemoved += Drop;
    }

    private void Drop(Item item) 
    {
        SpawnItem(item.data, item.Amount);
        
        OnItemDropped?.Invoke(new Item());
    }

    private void SpawnItem(ElementData elementData, int amount)
    {
        GameObject newItem = Instantiate(elementData.GetPrefab, transform.position, new Quaternion());
        ItemContainer container = newItem.GetComponentInChildren<ItemContainer>();
        
        container.ElementData = elementData;
        container.Amount = amount;

        CorrectTransform(newItem);
    }

    private void CorrectTransform(GameObject item)
    {
        CorrectTransform correctTransform = item.GetComponentInChildren<CorrectTransform>();
        correctTransform?.Setup();
    }
}