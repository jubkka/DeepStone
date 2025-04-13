using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[System.Serializable]
public class Rays
{
    public RaysType type;
    public float distance;
}

public enum RaysType
{
    Interact,
}

public class Raycaster : MonoBehaviour 
{
    [SerializeField] private Rays[] raysArray;
    [SerializeField] private LayerMask layerMask;
    
    private static LayerMask _layerMask;
    
    public static readonly Dictionary<RaysType, float> Rays = new();
    
    private void Awake() 
    {
        foreach (var item in raysArray)
        {
            Rays.TryAdd(item.type, item.distance);
        }

        _layerMask = layerMask;
    }
    
    public static void DrawRay(Vector3 origin, Vector3 direction, Color color) 
    {
        Debug.DrawRay(origin, direction, color);
    }

    public static bool Cast(Vector3 origin, Vector3 direction, float distance, out GameObject hitObject)
    {
        if (Physics.Raycast(origin, direction, out RaycastHit hit, distance, _layerMask))
        {
            hitObject = hit.collider.gameObject;
            return true;
        }
        
        hitObject = null;
        return false;
    }
}