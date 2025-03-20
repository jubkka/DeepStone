using UnityEngine;

public class InteractRay : MonoBehaviour 
{
    private Ray ray;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    public void DrawRay(float distance) 
    {
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.black);
    }

    public GameObject Cast(LayerMask layerMask, float distance = 2.5f) 
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