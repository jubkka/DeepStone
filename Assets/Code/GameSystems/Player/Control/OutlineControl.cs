using UnityEngine;

public class OutlineControl : MonoBehaviour
{
    [SerializeField] private InteractRay interactRay;
    private OutlineActivation lastOutline;

    private void Update()
    {
        DrawOutline(interactRay.Cast(LayerMask.GetMask("Item")));   
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
}