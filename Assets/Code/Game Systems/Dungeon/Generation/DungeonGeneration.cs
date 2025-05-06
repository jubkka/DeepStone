using Unity.AI.Navigation;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    [Header("Generation")]
    [SerializeField] private LevelGeneration levelGeneration;
    
    [Header("Spawners")]
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    
    [Header("NavMesh")]
    [SerializeField] private NavMeshSurface navMeshSurface;
    
    private void Start()
    {
        levelGeneration.GenerateLevel();
        navMeshSurface.BuildNavMesh();
        
        itemSpawner.Spawn();
        enemySpawner.Spawn();
    }
}