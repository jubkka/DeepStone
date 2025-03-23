using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Rays
{
    public string name;
    public float distance;
}

public class Raycaster : MonoBehaviour 
{
    [SerializeField] private Rays[] raysArray;
    public static Dictionary<string, float> Rays = new();
    private Ray ray;

    private void Awake() 
    {
        foreach (var item in raysArray)
            Rays.Add(item.name, item.distance);
    }

    public void DrawRay(float distance) 
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.black);
    }

    public GameObject Cast(Transform transform, LayerMask layerMask, float distance) 
    {
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        GameObject obj = null;

        if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
        {
            obj = hit.collider.gameObject;   
        }  

        return obj;
    }
}