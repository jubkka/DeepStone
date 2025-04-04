using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generation : MonoBehaviour
{
    public int levelSize;
    
    [SerializeField] private Room startRoom;
    [SerializeField] private List<Room> prefabRooms;

    [HideInInspector] public List<Vector3> occupiedCells;
    
    private Room[,] grid;
    public List<Room> placedRooms = new List<Room>();
    
    private Room currentRoom;
    private Room previousRoom;

    private void Start()
    {
        grid = new Room[levelSize, levelSize];
        
        GenerateLevel();
    }
    
    private void CreateDoorway(Room room, int minDoorWays)
    {
        int doorwayCount = Random.Range(minDoorWays, room.posibleDoorways.Count);

        for (int i = 0; i < doorwayCount; i++)
        {
            int index = Random.Range(0, room.posibleDoorways.Count);
            GameObject doorway = room.posibleDoorways[index];
            
            doorway.SetActive(false);
            
            room.posibleDoorways.Remove(doorway);
            room.activeDoorways.Add(doorway);
        }
    }
    
    private bool TryPlaceRoom1(Room room)
    {
        // currentRoom = room;
        // currentRoom.posibleDoorways.Shuffle();
        
        
        
        for (int i = 0; i < previousRoom.activeDoorways.Count; i++)
        {
            for (int j = 0; j < currentRoom.posibleDoorways.Count; j++)
            {
                for (int angle = 0; angle < 4; angle++)
                {
                    currentRoom.transform.rotation = Quaternion.identity;
                    currentRoom.transform.Rotate(Vector3.up, angle * 90f);
                    
                    Vector3 offset = previousRoom.activeDoorways[i].transform.position - currentRoom.posibleDoorways[j].transform.position;
                    currentRoom.transform.position += offset;
                    
                    bool canPlaceRoom = CanPlaceRoom(currentRoom, (int)currentRoom.transform.position.x, (int)currentRoom.transform.position.z);
                    
                    Debug.Log($"Name object: {currentRoom}. " +
                              $"Direction: {currentRoom.posibleDoorways[j].name}. " +
                              $"AngleCount: {angle}. " +
                              $"Angle:  {currentRoom.transform.rotation.eulerAngles}. " +
                              $"CanPlaceRoom: {canPlaceRoom}.");

                    if (canPlaceRoom)
                    {
                        ChangeDoorway(currentRoom, currentRoom.posibleDoorways[j]);
                        CreateDoorway(currentRoom, 1);
                        MoveRoom(currentRoom, (int)currentRoom.transform.position.x,
                            (int)currentRoom.transform.position.z);

                        return true;
                    }
                }
            }
        }
        
        Destroy(currentRoom.gameObject);
        
        return false;
    }

    private bool TryPlaceRoom(Room room)
    {
        int randomX = Random.Range(0, levelSize * 2);
        int randomZ = Random.Range(0, levelSize * 2);
        int angle = Random.Range(0, 3); // 0 - 0, 90 - 1, 180 - 2, 3 - 270 

        room.transform.Rotate(Vector3.up,angle * 90f);
        
        bool placedRoom = CanPlaceRoom(room, randomX, randomZ);

        if (placedRoom)
        {
            placedRooms.Add(room);
            CreateDoorway(room, 1);
            
            MoveRoom(room, randomX, randomZ);
            return true;
        }
        else
        {
            Destroy(room.gameObject);
            Debug.Log("Unable to place room.");
        }

        return false;
    }

    private void GenerateLevel()
    {
        PlaceStartRoom();
        GenerateRooms();
    }

    private void GenerateRooms()
    {
        for (int i = 0; i < 50; i++)
        {
            int index = Random.Range(0, prefabRooms.Count);
            Room randomRoom = PlaceRoom(prefabRooms[index], "room " + i.ToString());
            
            TryPlaceRoom(randomRoom);
        }

        foreach (var room in placedRooms)
        {
            TryPlaceRoom1(room);
        }
    }
    
    private void PlaceStartRoom()
    {
        int startX = levelSize / 2;
        int startZ = levelSize / 2;

        currentRoom = PlaceRoom(startRoom, "Start Room");
        MoveRoom(currentRoom, startX, startZ);
    }

    private void ChangeDoorway(Room room, GameObject doorway)
    {
        room.posibleDoorways.Remove(doorway);
        room.activeDoorways.Add(doorway);
        
        doorway.SetActive(false);
    }
    
    private Room PlaceRoom(Room room, string i)
    {
        GameObject roomObject = Instantiate(room.prefab, new Vector3(-100, 0, -100), Quaternion.identity);
        roomObject.name = i;
        Room newRoom = roomObject.GetComponent<Room>();

        return newRoom;
    }

    private void MoveRoom(Room room, int x, int z)
    {
        for (int i = 0; i < room.sizeX; i++)
        {
            for (int j = 0; j < room.sizeZ; j++)
            {
                int cellX = x + i - room.sizeX / 2;
                int cellZ = z + j - room.sizeZ / 2;
                
                grid[cellX, cellZ] = room;
                
                occupiedCells.Add(new Vector3(cellX, 0, cellZ));
            }
        }
        
        room.gameObject.transform.position = new Vector3(x, 0, z);

        // previousRoom = currentRoom;
        // currentRoom = null; 
    }

    private bool CanPlaceRoom(Room room, int x, int z)
    {
        for (int i = 0; i < room.sizeX; i++)
        {
            for (int j = 0; j < room.sizeZ; j++)
            {
                int posX = x + i - room.sizeX / 2;
                int posY = z + j - room.sizeZ / 2;
                
                if (posX >= levelSize || posY >= levelSize)
                    return false;
                
                if (posX < 0 || posY < 0)
                    return false;
                
                if (grid[posX, posY] != null)
                {
                    return false;
                }
            }
        }

        return true;
    }
}