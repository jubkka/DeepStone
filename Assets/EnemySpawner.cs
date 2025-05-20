using UnityEngine;

public class EnemySpawner : Spawner
{
    [Header("Enemies")]
    [SerializeField] private EnemyTable enemyTable;
    
    protected override GameObject RandomPrefab()
    {
        float totalWeight = 0f;
        
        foreach (var item in enemyTable.enemies)
            totalWeight += item.weight;

        float roll = Random.Range(0, totalWeight);
        float cumulative = 0;

        foreach (var itemLoot in enemyTable.enemies)
        {
            cumulative += itemLoot.weight;
            if (roll <= cumulative)
                return itemLoot.data.GetPrefab; 
        }

        return null;
    }
}
