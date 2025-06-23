using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomDoorwayLevel : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private GameObject door;
    [SerializeField] private int chanceSpawnDoor;
    
    [Header("Components")]
    [SerializeField] private GridLevel gridLevel;
    [SerializeField] private FloorLevel floorLevel;

    private int levelSize;

    public void Init(int levelSize)
    {
        this.levelSize = levelSize;
    }

    public void EnableDoorway(Room room, GameObject doorway)
    {
        room.possibleDoorways.Remove(doorway);
        room.activeDoorways.Add(doorway);
        
        doorway.GetComponent<MeshRenderer>().enabled = false;
        doorway.GetComponent<MeshCollider>().enabled = false;
    }
    
    public bool CreateExitDoorway(Room room)
    {
        GameObject doorway = GetRandomPossibleDoorway(room);
        List<Vector3> positions = GetCellsNearDoorways(doorway);

        if (positions.All(CanPlaceDoorway))
        {
            OccupyCellsNearDoorways(room, positions);
            EnableDoorway(room,doorway);
            CreateDoor(doorway.transform, false);

            return true;
        }
    
        return false;
    }
    
    public void CreateDoorway(Room room)
    {
        int doorwayCount = GetRandomCountDoorway(room);
        
        for (int i = 0; i < doorwayCount && room.possibleDoorways.Count > 0; i++)
        {
            GameObject doorway = GetRandomPossibleDoorway(room);
            Vector3 pos = GetForwardFromDoorway(doorway);
            
            if (!CanPlaceDoorway(pos))
                continue;

            EnableDoorway(room, doorway);
            CreateDoor(doorway.transform, true);
        }
    }

    private void CreateDoor(Transform doorway, bool isExitDoorway = false)
    {
        if (Random.Range(0, 100) > chanceSpawnDoor)
            return;
        
        Vector3 doorPosition = doorway.position;
        Vector3 offset = doorway.transform.forward * -0.5f;
        doorPosition += offset;

        if (isExitDoorway)
        {
            offset = doorway.transform.forward * 0.5f;
            doorPosition += offset;
        }

        GameObject doorObj = Instantiate(door, doorPosition, Quaternion.identity, doorway.transform.parent);
        doorObj.transform.localRotation = doorway.localRotation;
    }

    public void OccupyCellsNearDoorways(Room room, List<Vector3> positions)
    {
        foreach (var p in positions)
        {
            gridLevel.Grid[(int)p.x, (int)p.z] = room;
            floorLevel.FloorMap[(int)p.x, (int)p.z] = true;
            gridLevel.GetOccupiedCells.Add(p);
        }
    }
    
    public void OccupyRoomDoorways(List<Room> rooms)
    {
        foreach (var room in rooms)
        {
            foreach (var doorway in room.activeDoorways)
            {
                List<Vector3> positions = GetCellsNearDoorways(doorway);

                if (positions.All(CanPlaceDoorway))
                {
                    OccupyCellsNearDoorways(room, positions);
                }
            }
        }
    }
    
    public GameObject GetRandomPossibleDoorway(Room room)
    {
        int index = Random.Range(0, room.possibleDoorways.Count);
        return room.possibleDoorways[index];
    }
    
    public int GetRandomCountDoorway(Room room)
    {
        float total = room.chancesCreateDoorway.Sum(p => p.value);
        float rand = Random.Range(0f, total);

        float cumulative = 0f;

        foreach (var doorway in room.chancesCreateDoorway)
        {
            cumulative += doorway.value;
            
            if (rand < cumulative)
                return doorway.countDoorway;
        }

        return 0;
    }
    
    public Vector3 GetForwardFromDoorway(GameObject doorway)
    {
        float posX = doorway.transform.position.x;
        float posZ = doorway.transform.position.z;
        
        Vector3 pos = new Vector3(posX, 0, posZ);

        float forwardX = doorway.transform.forward.x;
        float forwardZ = doorway.transform.forward.z;
        
        return pos + new Vector3(forwardX, 0, forwardZ);
    }
    
    public List<Vector3> GetCellsNearDoorways(GameObject doorway)
    {
        Vector3 pos = GetForwardFromDoorway(doorway);
        
        Vector3 forward = doorway.transform.forward;
        Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;
        Vector3 left = -right;
        
        Vector3 forwardCell = pos;
        Vector3 leftForwardCell = forwardCell + left;   
        Vector3 rightForwardCell = forwardCell + right; 
        
        Vector3 centerCell = new Vector3(doorway.transform.position.x, 0f, doorway.transform.position.z);
        Vector3 centerLeftCell = centerCell + left;
        Vector3 centerRightCell = centerCell + right;
        
        var positions = new List<Vector3>()
        {
            centerCell,
            centerLeftCell,
            centerRightCell,
            forwardCell,
            leftForwardCell,
            rightForwardCell
        };

        return positions;
    }
    
    public bool CanPlaceDoorway(Vector3 pos)
    {
        if (pos.x >= levelSize || pos.z >= levelSize ||
            pos.x < 0 || pos.z < 0)
            return false;
        
        if (gridLevel.Grid[(int)pos.x, (int)pos.z] != null)
            return false;

        return true;
    }
}