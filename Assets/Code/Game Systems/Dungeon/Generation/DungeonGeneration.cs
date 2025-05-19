using Unity.AI.Navigation;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    [Header("Generation")]
    [SerializeField] private LevelGeneration levelGeneration;
    
    [Header("Spawners")]
    [SerializeField] private ItemSpawner itemSpawner;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private PlayerSpawner playerSpawner;
    
    [Header("NavMesh")]
    [SerializeField] private NavMeshSurface navMeshSurface;
    
    private void Start()
    {
        BuildLevel();
        Spawn();
    }

    private void BuildLevel()
    {
        levelGeneration.GenerateLevel();
        navMeshSurface.BuildNavMesh();
    }

    private void Spawn()
    {
        itemSpawner.Spawn();
        enemySpawner.Spawn();
        playerSpawner.Spawn();
    }
}