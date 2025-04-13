using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
     [Header("Room GameObject")]
     public GameObject prefab;

     [Header("Room Doorways")]
     public List<GameObject> posibleDoorways = new List<GameObject>();
     public List<GameObject> activeDoorways = new List<GameObject>();
     
     [Space(10)]
     [SerializeField] public List<ChanceDoorway> chancesCreateDoorway = new List<ChanceDoorway>();

     [Header("Floor Cells")]
     [SerializeField] private List<Vector2Int> occupiedFloorCells = new List<Vector2Int>();
     
     [Header("Wall Cells")]
     [SerializeField] private List<Vector2Int> occupiedWallCells = new List<Vector2Int>();
     public int GetWallCountOccupiedCells => occupiedWallCells.Count;
     
     [Header("Containers")]
     [SerializeField] private GameObject containerFloors;
     [SerializeField] private GameObject containerWalls;

     private void Start()
     {
          FillFloorOccupiedCells();
          FillWallOccupiedCells();
     }
     
     public IEnumerable<Vector3Int> GetFloorCells()
     {
          foreach (var cells in occupiedFloorCells)
          {
               Vector3Int worldPos = new Vector3Int(cells.x, 0, cells.y);
            
               yield return worldPos;
          }
     }
     
     public IEnumerable<Vector3Int> GetWallCells()
     {
          foreach (var cells in occupiedWallCells)
          {
               Vector3Int worldPos = new Vector3Int(cells.x, 0, cells.y);

               yield return worldPos;
          }
     }

     // private Vector3Int TransformCellsToWorldPosition(int x, int z)
     // {
     //      Vector3 worldPos = transform.TransformPoint(new Vector3(x, 0f, z));
     //        
     //      x = Mathf.RoundToInt(worldPos.x);
     //      z = Mathf.RoundToInt(worldPos.z);
     //      
     //      return new Vector3Int(x, 0, z);
     // }

     public void FillFloorOccupiedCells()
     {
          occupiedFloorCells.Clear();
          MeshRenderer[] renderers = containerFloors.GetComponentsInChildren<MeshRenderer>();

          FillOccupiedCells(renderers, occupiedFloorCells);
     }
     
     public void FillWallOccupiedCells()
     {
          occupiedWallCells.Clear();
          
          MeshRenderer[] renderers = containerWalls.GetComponentsInChildren<MeshRenderer>();

          FillOccupiedCells(renderers, occupiedWallCells);
     }
     
     private void FillOccupiedCells(MeshRenderer[] renderers, List<Vector2Int> occupiedCells)
     {
          foreach (var rend in renderers)
          {
               if (rend != null)
               {
                    Bounds bounds = rend.bounds;
                    Vector3 min = bounds.min;
                    Vector3 max = bounds.max;

                    for (int x = Mathf.RoundToInt(min.x); x <= Mathf.RoundToInt(max.x); x++)
                    {
                         for (int z = Mathf.RoundToInt(min.z); z <= Mathf.RoundToInt(max.z); z++)
                         {
                              Vector2Int cell = new Vector2Int(x, z);
                              if (!occupiedCells.Contains(cell))
                                   occupiedCells.Add(cell);
                         }
                    }
               }
          }
     }

}