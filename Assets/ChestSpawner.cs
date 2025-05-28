using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chestPrefab;
    
    [SerializeField] private ChestInput chestInput; //TODO remove serializeField
    
    private void Init(ChestInput input)
    {
        chestInput = input;
    }

    public void Spawn()
    {
        //Spawn TODO
    }

    private void Start() // late delete TODO
    {
        foreach (var chest in FindObjectsOfType<ChestInteractable>())
        {
            chest.Init(chestInput);
        }
    }
}
