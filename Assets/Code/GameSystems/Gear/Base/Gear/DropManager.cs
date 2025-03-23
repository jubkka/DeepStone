using UnityEngine;

public class DropManager : MonoBehaviour
{
    public void Drop(Item item) 
    {
        ItemData itemData = item.data;
        int amount = item.Amount;

        GameObject newitem = Instantiate(itemData.GetPrefab, transform.position, new Quaternion());
        ItemContainer container = newitem.GetComponentInChildren<ItemContainer>();

        container.ItemData = itemData;
        container.Amount = amount;
    }
}