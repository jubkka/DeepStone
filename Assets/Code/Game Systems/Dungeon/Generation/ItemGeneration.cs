using System.Collections.Generic;
using UnityEngine;

public class ItemGeneration: MonoBehaviour
{
    [Header("Container Items")]
    [SerializeField] private Transform containerItems;
    
    [Header("Items")]
    [SerializeField] private List<ItemData> items = new List<ItemData>();
    [SerializeField] private List<Vector3> spawnedItems = new List<Vector3>();

    [Header("Generation Settings")] 
    [SerializeField] private int maxItems;
    [SerializeField] private int maxTriesSpawnItem;
    
    private GridLevel gridLevel;
    private int levelSize;

    private void Start()
    {
        gridLevel = GetComponentInChildren<GridLevel>();
        levelSize = gridLevel.Grid.GetLength(0);
    }

    public void ItemsSpawn()
    {
        int countTries = 0;

        while (spawnedItems.Count < maxItems && countTries < maxTriesSpawnItem)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();

            if (CheckFreeCells(spawnPosition))
            {
                SpawnItem(RandomItem(), spawnPosition);
                countTries = 0;
            }
            else
                countTries++;
        }
    }

    private bool CheckFreeCells(Vector3 spawnPosition)
    {
        foreach (var cells in gridLevel.GetOccupiedCellsByWalls)
        {
            if (cells == spawnPosition && !spawnedItems.Contains(spawnPosition))
                return false;
        }

        return true;
    }

    private Vector3 GetRandomSpawnPosition()
    {
        int x = Random.Range(0, levelSize);
        int z = Random.Range(0, levelSize);
            
        return new Vector3(x, 0, z);
    }

    private ItemData RandomItem()
    {
        int index = Random.Range(0, items.Count);
        return items[index];
    }

    private void SpawnItem(ItemData item, Vector3 spawnPosition)
    {
        Instantiate(item.GetPrefab, spawnPosition, Quaternion.identity, containerItems);
        spawnedItems.Add(spawnPosition);
    }
}