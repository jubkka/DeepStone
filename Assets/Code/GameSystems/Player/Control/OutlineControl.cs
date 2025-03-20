using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    [SerializeField] private InteractRay interactRay;
    [SerializeField] private LayerMask outlineLayerMask;
    private OutlineActivation lastOutline;

    private void Update()
    {
        DrawOutline(interactRay.Cast(outlineLayerMask));   
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