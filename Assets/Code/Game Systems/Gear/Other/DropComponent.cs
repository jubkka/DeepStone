using System;
using UnityEngine;

public class DropComponent : MonoBehaviour
{
    public event Action<Item> OnItemDropped;
    
    private void Start()
    {
        InventoryComponent inventory = GearSystems.Instance.Inventory;
        inventory.OnItemRemoved += Drop;
    }

    private void Drop(Item item) 
    {
        SpawnItem(item);
        
        OnItemDropped?.Invoke(item);
    }

    private void SpawnItem(Item item)
    {
        GameObject newItem = Instantiate(item.data.GetPrefab, new Vector3(transform.position.x, 0f, transform.position.z), new Quaternion());
        GenericContainer container = newItem.GetComponentInChildren<GenericContainer>();

        container.CreateNewItem(item);

        CorrectTransform(newItem);
    }

    private void CorrectTransform(GameObject item)
    {
        CorrectTransform correctTransform = item.GetComponentInChildren<CorrectTransform>();
        correctTransform?.Setup();
    }
}