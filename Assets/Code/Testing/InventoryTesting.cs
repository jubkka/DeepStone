using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventory;
    public Item simpleItem;
    public Item stackItem;
    public int amount;
    public int stack;

    public void SimpleAddToInventory() => inventory.AddItem(new ItemSlot(simpleItem, amount), stack);
    public void StackAddToInventory() => inventory.AddItem(new ItemSlot(stackItem, amount), stack);
}
