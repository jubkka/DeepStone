using UnityEngine;

public class InteractRay : MonoBehaviour 
{
    private Ray ray;
    public float distance = 1f;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        DrawRay(); 
    }

    private void DrawRay() 
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.black);
    }

    public GameObject Cast(LayerMask layerMask) 
    {
        ray = new Ray(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward));

        GameObject obj = null;

        if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
        {
            obj = hit.collider.gameObject;   
        }  

        return obj;
    }
}