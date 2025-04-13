using UnityEngine;

public class OutlineManager : MonoBehaviour
{
    private OutlineActivation lastOutline;
    
    private Transform cam;
    private float distance;

    private void Start() 
    {
        cam = Camera.main.transform;
        distance = Raycaster.Rays[RaysType.Interact];
    }

    private void Update()
    {
        DrawOutline();
    }

    private void DrawOutline()
    {
        if (!Raycaster.Cast(cam.position, cam.forward, distance, out GameObject target)) 
        {
            if (lastOutline) lastOutline.DisableLastOutline();

            return;
        }

        OutlineActivation outlineActivation = target?.GetComponentInChildren<OutlineActivation>();
        
        if (outlineActivation == null)
            return;

        if (outlineActivation.IsColorOn) 
            return;

        if (lastOutline && lastOutline != outlineActivation) 
            lastOutline.DisableLastOutline();
        
        lastOutline = outlineActivation.EnableOutline();
    }
}