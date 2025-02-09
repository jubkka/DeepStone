using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventory;
    public ItemData simpleItem;
    public ItemData stackItem;
    public int amount;

    public void SimpleAddToInventory() => inventory.AddItem(new Item(simpleItem, amount));
    public void StackAddToInventory() => inventory.AddItem(new Item(stackItem, amount));
}
