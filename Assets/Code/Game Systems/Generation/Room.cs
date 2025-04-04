using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
     public int sizeX;
     public int sizeZ;
     
     public GameObject prefab;
     
     public List<GameObject> posibleDoorways = new List<GameObject>();
     public List<GameObject> activeDoorways = new List<GameObject>();
}