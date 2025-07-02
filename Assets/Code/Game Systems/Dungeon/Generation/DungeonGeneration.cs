using System.Collections;
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
        BuildLevel();
        Spawns();
    }

    private void BuildLevel()
    {
        levelGeneration.GenerateLevel();

        StartCoroutine(OnBuildMesh());
    }

    private void Spawns()
    {
        itemSpawner.Spawn();
        enemySpawner.Spawn();
    }

    private IEnumerator OnBuildMesh()
    {
        yield return null;
        navMeshSurface.BuildNavMesh();
        yield return new WaitForSeconds(0.1f);
    }
}