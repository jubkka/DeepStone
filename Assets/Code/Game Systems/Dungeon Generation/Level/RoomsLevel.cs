using System.Collections.Generic;
using UnityEngine;

public class RoomsLevel : MonoBehaviour
{
    [SerializeField] private Transform containerRooms;
    
    private GridLevel gridLevel;
    private RoomDoorwayLevel roomDoorwayLevel;
    
    private Room startRoom;
    private int levelSize;
    private List<Room> prefabRooms;

    private List<Room> placedRooms = new List<Room>();
    public List<Room> PlacedRooms => placedRooms;

    public void Init(Room startRoom, int levelSize, List<Room> prefabRooms)
    {
        gridLevel = GetComponentInParent<GridLevel>();
        roomDoorwayLevel = GetComponent<RoomDoorwayLevel>();

        roomDoorwayLevel.Init(levelSize);
        
        this.levelSize = levelSize;
        this.startRoom = startRoom;
        this.prefabRooms = prefabRooms;
    }

    private Room PlaceRoom(Room room, Vector3 position, Quaternion rotation)
    {
         GameObject roomObject = Instantiate(room.prefab, position, rotation, containerRooms);
         Room newRoom = roomObject.GetComponent<Room>();

         FillCells(newRoom);
         
         return newRoom;
    }

    private void FillCells(Room room)
    {
        room.FillFloorOccupiedCells();
        room.FillWallOccupiedCells();
    }

    public void PlaceStartRoom(int startX, int startZ)
    {
        Vector3 position = new Vector3(startX, -1f, startZ);
        Quaternion rotation = Quaternion.identity;

        Room room = PlaceRoom(startRoom, position, rotation);
         
        gridLevel.AddRoomToGrid(room);
        roomDoorwayLevel.CreateExitDoorway(room);
        placedRooms.Add(room);
    }
    
    public void GenerateRooms(int tries)
    {
        for (int i = 0; i < tries; i++)
            TryPlaceRoom();
        
        gridLevel.SetWallCells(PlacedRooms);
    }
     
    public bool TryPlaceRoom()
    {
        Vector3 pos = new Vector3(Random.Range(0, levelSize * 2), -0.5f, Random.Range(0, levelSize * 2));
        Quaternion rotation = Quaternion.Euler(0, Random.Range(0,4) * 90, 0);
         
        int index = Random.Range(0, prefabRooms.Count);
        Room room = PlaceRoom(prefabRooms[index], pos, rotation); ;
         
        bool placedRoom = CanPlaceRoom(room);
         
        if (placedRoom)
        {
            gridLevel.AddRoomToGrid(room);

            if (!roomDoorwayLevel.CreateExitDoorway(room))
            {
                gridLevel.DeleteRoomFromGrid(room);
                return false;
            }
             
            roomDoorwayLevel.CreateDoorway(room);
            
            ExpendRoom(room);
            placedRooms.Add(room);
            return true;
        }
         
        Destroy(room.gameObject);

        return false;
    }
     
    private void ExpendRoom(Room oldRoom)
    {
        List<Room> rooms = new List<Room> { oldRoom };

        foreach (var prefab in prefabRooms)
        {
            Room newRoom = PlaceRoom(prefab, new Vector3(), Quaternion.identity);
            newRoom.posibleDoorways.Shuffle();
         
            bool placedRoom = false;
             
            for (int i = 0; i < oldRoom.activeDoorways.Count && !placedRoom; i++)
            {
                for (int j = 0; j < newRoom.posibleDoorways.Count && !placedRoom; j++)
                {
                    for (int angle = 0; angle < 4; angle++)
                    {
                        newRoom.transform.Rotate(Vector3.up, angle * 90f);
                 
                        Vector3 offset = oldRoom.activeDoorways[i].transform.position - newRoom.posibleDoorways[j].transform.position;
                        newRoom.transform.position += offset;

                        FillCells(newRoom);
                         
                        bool canPlaceRoom = CanPlaceRoom(newRoom);
         
                        if (canPlaceRoom)
                        {
                            roomDoorwayLevel.EnableDoorway(newRoom, newRoom.posibleDoorways[j]);
                            roomDoorwayLevel.CreateDoorway(newRoom);
                             
                            gridLevel.AddRoomToGrid(newRoom);
         
                            ExpendRoom(newRoom);
                             
                            rooms.Add(newRoom);
                            placedRooms.Add(newRoom);
         
                            placedRoom = true;
                            break;
                        }
                    }
                }
            }
             
            if (!placedRoom)
                Destroy(newRoom.gameObject);
        }

        roomDoorwayLevel.OccupyRoomDoorways(rooms);
    }
     
    private void TestPlaceRoom()
    {
        // Vector3 pos = new Vector3(50, 0, 50);
        // Quaternion rotation = Quaternion.Euler(0,90,0);
        //  
        // Room room = PlaceRoom(testRoom, pos, rotation);
        //  
        // grid.AddRoomToGrid(room);
    }
    
    private bool CanPlaceRoom(Room room)
    {
        foreach (Vector3Int cells in room.GetFloorCells())
        {
            if (!roomDoorwayLevel.CanPlaceDoorway(cells))
                return false;
        }
        
        return true;
    }
}