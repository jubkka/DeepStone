using System.Collections.Generic;
using UnityEngine;

public class FloorLevel : MonoBehaviour
{
    [SerializeField] private Material floorMaterial;
    
    private GridLevel gridLevel;
    
    private bool[,] floorMap;
    public bool[,] FloorMap => floorMap;
    
    private void Start()
    {
        gridLevel = GetComponent<GridLevel>();
    }

    public void Init(int levelSize)
    {
        floorMap = new bool[levelSize, levelSize];
    }

    public void SetFloor()
    {
        int size = floorMap.GetLength(0);
        
        for (int x = 0; x < size; x++)
        {
            for (int z = 0; z < size; z++)
            {
                if (gridLevel.Grid[x, z] == null)
                {
                    gridLevel.GetOccupiedCells.Add(new Vector3(x, 0, z));
                    floorMap[x,z] = true;
                }
            }
        }

        GenerateFloorMesh();
    }

    private void GenerateFloorMesh()
    {
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();
        
        int width = floorMap.GetLength(0);
        int height = floorMap.GetLength(1);

        int vertIndex = 0;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                if (floorMap[x, z])
                {
                    Vector3 pos = new Vector3(x, 0, z);
                    
                    //Вершины
                    vertices.Add(pos + new Vector3(0,0,0));
                    vertices.Add(pos + new Vector3(0,0,1f));
                    vertices.Add(pos + new Vector3(1f,0,1f));
                    vertices.Add(pos + new Vector3(1f,0,0));
                    
                    //2 треугольника на квадрат
                    triangles.Add(vertIndex + 0);
                    triangles.Add(vertIndex + 1);
                    triangles.Add(vertIndex + 2);
                    
                    triangles.Add(vertIndex + 0);
                    triangles.Add(vertIndex + 2);
                    triangles.Add(vertIndex + 3);
                    
                    uvs.Add(new Vector2(0,0));
                    uvs.Add(new Vector2(0,1));
                    uvs.Add(new Vector2(1,1));
                    uvs.Add(new Vector2(1,0));
                    
                    vertIndex += 4;
                }                
            }
        }
        
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uvs.ToArray();
        
        mesh.RecalculateNormals();
        
        GameObject floorObj = new GameObject("Floor", typeof(MeshFilter), typeof(MeshRenderer));
        floorObj.transform.position = new Vector3();
        floorObj.GetComponent<MeshFilter>().mesh = mesh;
        floorObj.GetComponent<MeshRenderer>().material = floorMaterial;
    }
}