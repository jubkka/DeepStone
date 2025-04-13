using System.Collections.Generic;
using UnityEngine;

public class GridLevel : MonoBehaviour
{
    private Room[,] grid;
    public Room[,] Grid => grid;
    
    private List<Vector3> occupiedCells = new List<Vector3>();
    public List<Vector3> GetOccupiedCells => occupiedCells;
    
    private List<Vector3> occupiedCellsByWalls = new List<Vector3>();
    public List<Vector3> GetOccupiedCellsByWalls => occupiedCellsByWalls;

    public void Init(int levelSize)
    {
        grid = new Room[levelSize, levelSize];
    }

    public void AddRoomToGrid(Room room)
    {
        foreach (Vector3Int cells in room.GetFloorCells())
        {
            grid[cells.x, cells.z] = room;
            occupiedCells.Add(new Vector3(cells.x, 0, cells.z));
        }
    }
    
    public void DeleteRoomFromGrid(Room room)
    {
        foreach (Vector3Int cells in room.GetFloorCells())
        {
            grid[cells.x, cells.z] = null;
            occupiedCells.Remove(new Vector3(cells.x, 0, cells.z));
        }

        Destroy(room.gameObject);
    }
    
    public void SetWallCells(List<Room> rooms)
    {
        foreach (var room in rooms)
        {
            foreach (Vector3Int cells in room.GetWallCells())
            {
                occupiedCellsByWalls.Add(new Vector3(cells.x, 0, cells.z));
            }
        }
    }
}