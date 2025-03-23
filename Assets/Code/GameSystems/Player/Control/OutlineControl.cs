using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    [SerializeField] private Raycaster interactRay;
    [SerializeField] private LayerMask outlineLayerMask;
    private OutlineActivation lastOutline;
    private Transform cameraPosition;
    private float outlineDistance;

    private void Start() 
    {
        cameraPosition = Camera.main.transform;
        outlineDistance = Raycaster.Rays["Interact"];
    }

    private void Update()
    {
        DrawOutline(interactRay.Cast(cameraPosition, outlineLayerMask, outlineDistance));   
    }

    public void DrawOutline(GameObject obj) 
    {
        if (obj == null) 
        {
            if (lastOutline) lastOutline.DisableLastOutline();

            return;
        }

        OutlineActivation outlineActivation = obj.GetComponentInChildren<OutlineActivation>();

        if (outlineActivation == null)
            return;

        if (lastOutline && lastOutline != outlineActivation) lastOutline.DisableLastOutline();
        
        lastOutline = outlineActivation.EnableOutline();
    }
}