using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [Header("Container")]
    [SerializeField] protected Transform container;
    
    [Header("Spawned")]
    [SerializeField] protected List<Vector3> spawnedPos = new List<Vector3>();
    
    [Header("Generation Settings")] 
    [SerializeField] protected int maxObj;
    [SerializeField] protected int maxTriesSpawn;

    [Header("Components")] 
    [SerializeField] protected GridLevel gridLevel;
    
    private int levelSize;
    public List<Vector3> SpawnedPos => spawnedPos;
    
    protected void Start()
    {
        levelSize = gridLevel.Grid.GetLength(0);
    }
    
    public virtual void Spawn()
    {
        int countTries = 0;

        while (spawnedPos.Count < maxObj && countTries < maxTriesSpawn)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            
            if (CheckFreeCells(spawnPosition))
            {
                Create(RandomPrefab(), spawnPosition);
                countTries = 0;
            }
            else
                countTries++;
        }
    }
    
    protected void Create(GameObject prefab, Vector3 spawnPos)
    {
        Instantiate(prefab, spawnPos, Quaternion.identity, container);
        spawnedPos.Add(spawnPos);
    }
    
    protected bool CheckFreeCells(Vector3 spawnPosition)
    {
        foreach (var cells in gridLevel.GetOccupiedCellsByObstacles)
        {
            if (cells == spawnPosition && !spawnedPos.Contains(spawnPosition))
                return false;
        }

        return true;
    }
    
    protected Vector3 GetRandomSpawnPosition()
    {
        int x = Random.Range(0, levelSize);
        int z = Random.Range(0, levelSize);
            
        return new Vector3(x, 0, z);
    }

    protected abstract GameObject RandomPrefab();
}