using System;
using UnityEngine;

public class ItemSpawnManager : MonoBehaviour
{
    private InventoryComponent inventory;
    
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

    private void Start()
    {
        inventory = GearSystems.Instance.Inventory;
    }

    public void AddSword() => inventory.AddItem(new Item(sword, amount), 0);
    public void AddPotion() => inventory.AddItem(new Item(potion, amount), 0);
    public void AddHelmet() => inventory.AddItem(new Item(helmet, amount), 0);
    public void AddHelmet2() => inventory.AddItem(new Item(helmet2, amount), 0);
    public void AddChestplate() => inventory.AddItem(new Item(chestplate, amount), 0);
    public void Addpants() => inventory.AddItem(new Item(pants, amount), 0);
    public void Addboots() => inventory.AddItem(new Item(boots, amount), 0);
    public void AddRing() => inventory.AddItem(new Item(ring, amount), 0);
    public void AddNecklace() => inventory.AddItem(new Item(necklace, amount), 0);
}
