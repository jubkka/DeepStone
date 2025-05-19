using System.Collections.Generic;
using UnityEngine;

public class DoorwayGizmo : MonoBehaviour
{
    [SerializeField] private List<GameObject> doorways = new List<GameObject>();
    private void OnDrawGizmos()
    {
        if (doorways.Count <= 0)
            return;

        foreach (GameObject doorway in doorways)
        {
            if (doorway.activeSelf)
                Gizmos.color = Color.yellow;
            else
                Gizmos.color = Color.green;
            
            Gizmos.DrawCube(doorway.transform.position, Vector3.one * 0.5f);
        
            Gizmos.DrawLine(doorway.transform.position, doorway.transform.position + doorway.transform.forward * 2f);
            
        }
    }
}
