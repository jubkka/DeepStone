using System;
using UnityEngine;

public class DropComponent : MonoBehaviour
{
    public event Action<Item> OnItemDropped;
    
    public void Initialize(InventoryComponent inventory)
    {
        inventory.OnItemDropped += Drop;
    }

    private void Drop(Item item) 
    {
        SpawnItem(item);
        
        SFXAudioManager.Instance.PlaySound("ItemDropped");
        
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
        correctTransform?.SetupSpawning();
    }
}