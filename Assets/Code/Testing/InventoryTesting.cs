using UnityEngine;

public class InventoryTesting : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventory;
    public ItemData sword;
    public ItemData potion;
    public ItemData helmet;
    public int amount;

    public void SwordAddToInventory() => inventory.AddItem(new Item(sword, amount));
    public void PotionAddToInventory() => inventory.AddItem(new Item(potion, amount));
    public void HelmetAddToInventory() => inventory.AddItem(new Item(helmet, amount));
}
