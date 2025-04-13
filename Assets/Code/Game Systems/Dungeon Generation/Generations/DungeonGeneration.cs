using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    [SerializeField] private ItemGeneration itemGeneration;
    [SerializeField] private LevelGeneration levelGeneration;
    
    private void Start()
    {
        levelGeneration.GenerateLevel();
        itemGeneration.ItemsSpawn();
    }
}