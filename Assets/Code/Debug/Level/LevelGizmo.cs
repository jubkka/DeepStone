using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;

public class LevelGizmo : MonoBehaviour
{
    [SerializeField] private GridLevel grid;

    [Header("Testing")] 
    [SerializeField] private bool CanShowOccupiedCells;
    [SerializeField] private bool CanShowWallsOccupiedCells;
    [Space(10)]

    public List<Vector3> occupiedCells;
    public List<Vector3> occupiedCellsByWalls;

    private Vector3 bottomLeft;
    private Vector3 bottomRight;
    
    private Vector3 topLeft;
    private Vector3 topRight;
    
    public void OnDrawGizmos()
    {
        DrawPlacedRooms();
    }
    
    private void DrawPlacedRooms()
    {
        Init();

        if (CanShowOccupiedCells)
        {
            Gizmos.color = Color.red;
        
            foreach (var cells in occupiedCells)
            {
                Gizmos.DrawCube(new Vector3(cells.x, -1f, cells.z), Vector3.one);
            }
        }

        if (CanShowWallsOccupiedCells)
        {
            Gizmos.color = Color.green;
        
            foreach (var cells in occupiedCellsByWalls)
            {
                Gizmos.DrawCube(new Vector3(cells.x, -1f, cells.z), Vector3.one);
            }
        }
    }

    private void Init()
    {
        occupiedCells = grid?.GetOccupiedCells;
        occupiedCellsByWalls = grid?.GetOccupiedCellsByWalls;
    }
}
