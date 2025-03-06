using UnityEngine;

public class InteractRay : MonoBehaviour 
{
    private Ray ray;
    public float Distance {get; set;}
    private Transform cameraTransform;
    private OutlineActivation lastOutline;

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
        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.black);
    }

    public void DrawOutline(GameObject obj) 
    {
        if (obj == null) 
        {
            if (lastOutline) lastOutline.DisableLastOutline();
            return;
        }

        if (obj.TryGetComponent(out OutlineActivation outline))
        {
            if (lastOutline && lastOutline != outline) lastOutline.DisableLastOutline();
        
            lastOutline = outline.EnableOutline();
        }
    }

    public GameObject Cast(LayerMask layerMask) 
    {
        ray = new Ray(cameraTransform.position, cameraTransform.TransformDirection(Vector3.forward));

        GameObject obj = null;

        if (Physics.Raycast(ray, out RaycastHit hit, Distance, layerMask))
        {
            obj = hit.collider.gameObject;   
        }  

        return obj;
    }


}