using UnityEngine;

public class ChestSpawnerLevel : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] [Range(0f, 1f)] private float chanceSpawnDoor;

    public void TrySpawnChest(Room room)
    {
        if (Random.value < chanceSpawnDoor)
            return;

        GameObject chest = room.possibleChest;
        
        if (chest == null)
            return;
        
        chest.SetActive(true);
        chest.GetComponentInChildren<ChestFiller>().Fill();

        room.FillChestOccupiedCells();
    }
}