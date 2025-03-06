using QuickOutline;
using UnityEngine;

public class OutlineActivation : MonoBehaviour
{
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    public OutlineActivation EnableOutline() 
    {
        outline.enabled = true;

        return this;
    }

    public void DisableLastOutline() 
    {
        outline.enabled = false;
    }
}
