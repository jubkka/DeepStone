using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventory;
    public ItemData sword;
    public ItemData potion;
    public ItemData helmet;
    public ItemData helmet2;
    public ItemData chestplate;
    public ItemData pants;
    public ItemData boots;
    public ItemData ring;
    public ItemData necklace;
    public int amount;

    public void AddSword() => inventory.AddItem(new Item(sword, amount));
    public void AddPotion() => inventory.AddItem(new Item(potion, amount));
    public void AddHelmet() => inventory.AddItem(new Item(helmet, amount));
    public void AddHelmet2() => inventory.AddItem(new Item(helmet2, amount));
    public void AddChestplate() => inventory.AddItem(new Item(chestplate, amount));
    public void Addpants() => inventory.AddItem(new Item(pants, amount));
    public void Addboots() => inventory.AddItem(new Item(boots, amount));
    public void AddRing() => inventory.AddItem(new Item(ring, amount));
    public void AddNecklace() => inventory.AddItem(new Item(necklace, amount));
}
