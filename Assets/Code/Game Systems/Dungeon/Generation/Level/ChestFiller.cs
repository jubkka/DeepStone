using UnityEngine;

public class ChestFiller : MonoBehaviour
{
    [SerializeField] private ItemTable itemTable;
    [SerializeField] private ChestContainer chestContainer;
    
    public void Fill()
    {
        foreach (var itemLoot in itemTable.items)
        {
            if (chestContainer.Items.Count >= 9)
                break;

            if (Random.value <= itemLoot.weight)
            {
                AddItemToChest(itemLoot.data, itemLoot.amount);
            }
        }
    }

    private void AddItemToChest(ItemData itemData, int amount = 1)
    {
        Item item = new Item(itemData, amount);
        
        chestContainer.Items.Add(item);
    }
}