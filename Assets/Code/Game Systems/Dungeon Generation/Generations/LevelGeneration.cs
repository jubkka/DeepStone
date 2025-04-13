using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGeneration : MonoBehaviour
{
    [Header("Generation Settings")]
    public int levelSize;
    public int triesForGenerateRoom;
    
    [Header("Require Generate")]
    [SerializeField] private GameObject borders;
    [SerializeField] private Room startRoom;
    
    [Header("Rooms")]
    [SerializeField] private List<Room> prefabRooms;

    [Space(25)]
    [Header("TESTING")]
    [SerializeField] private Room testRoom;
    [SerializeField] private bool canGenerateFloor;
    
    private GridLevel gridLevel;
    private FloorLevel floorLevel;
    private RoomsLevel roomsLevel;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        gridLevel = GetComponentInChildren<GridLevel>();
        floorLevel = GetComponentInChildren<FloorLevel>();
        roomsLevel = GetComponentInChildren<RoomsLevel>();
        
        gridLevel.Init(levelSize);
        floorLevel.Init(levelSize);
        roomsLevel.Init(startRoom, levelSize, prefabRooms);
        
        SortRooms();
    }

    private void SortRooms()
    {
        prefabRooms.Sort((room1, room2) =>
            room2.GetWallCountOccupiedCells.CompareTo(room1.GetWallCountOccupiedCells));
    }
    
    public void GenerateLevel()
    {
        roomsLevel.PlaceStartRoom(levelSize / 2, levelSize / 2);
        PlaceBorders();
        
        roomsLevel.GenerateRooms(triesForGenerateRoom);
        
        if (canGenerateFloor)
            floorLevel.SetFloor();
    }

    private void PlaceBorders()
    {
        Instantiate(borders, new Vector3(50f, 1f, 50f), Quaternion.identity, transform);
    }
}