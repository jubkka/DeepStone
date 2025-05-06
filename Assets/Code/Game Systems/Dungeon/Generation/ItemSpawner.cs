using UnityEngine;

public class ItemSpawner: Spawner
{
    [Header("Items")]
    [SerializeField] private ItemTable itemTable;
    
    protected override GameObject RandomPrefab()
    {
        float totalWeight = 0f;
        
        foreach (var item in itemTable.items)
            totalWeight += item.weight;

        float roll = Random.Range(0, totalWeight);
        float cumulative = 0;

        foreach (var itemLoot in itemTable.items)
        {
            cumulative += itemLoot.weight;
            if (roll <= cumulative)
                return itemLoot.data.GetPrefab; 
        }

        return null;
    }
}


