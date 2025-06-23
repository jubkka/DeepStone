using System.Collections.Generic;
using UnityEngine;

public class ExitDoorLevel : MonoBehaviour
{
    [SerializeField] private GameObject exitDoor;
    [SerializeField] private GridLevel gridLevel;

    private List<Vector2Int> occupiedExitDoorCells = new List<Vector2Int>();

    public void SpawnExitDoor()
    {
        List<Vector3> exitDoorPositions;

        bool found = false;

        do
        {
            exitDoorPositions = GetRandomSpawnPositions();

            found = true;

            foreach (var pos in exitDoorPositions)
            {
                Vector2Int cell = new Vector2Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z));
                if (gridLevel.GetOccupiedCells.Contains(new Vector3(cell.x, 0, cell.y)))
                {
                    found = false;
                    break;
                }
            }

        } while (!found);

        FillCells(exitDoorPositions);
        gridLevel.SetExitDoorCells(this);
        
        Vector3 center = (exitDoorPositions[0] + exitDoorPositions[3]) / 2f;
        Instantiate(exitDoor, center, exitDoor.transform.rotation);
    }

    private List<Vector3> GetRandomSpawnPositions()
    {
        int x = Random.Range(0, gridLevel.Grid.GetLength(0) - 1);
        int z = Random.Range(0, gridLevel.Grid.GetLength(1) - 1);

        return new List<Vector3>()
        {
            new Vector3(x, 0, z),
            new Vector3(x, 0, z + 1),
            new Vector3(x + 1, 0, z),
            new Vector3(x + 1, 0, z + 1),
        };
    }

    private void FillCells(List<Vector3> positions)
    {
        occupiedExitDoorCells.Clear();
        
        foreach (var pos in positions)
        {
            Vector2Int cell = new Vector2Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z));
            if (!occupiedExitDoorCells.Contains(cell))
                occupiedExitDoorCells.Add(cell);
        }
    }

    public IEnumerable<Vector3Int> GetCells()
    {
        foreach (var cell in occupiedExitDoorCells)
            yield return new Vector3Int(cell.x, 0, cell.y);
    }
}
