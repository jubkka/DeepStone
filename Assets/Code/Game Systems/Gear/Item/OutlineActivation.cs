using QuickOutline;
using UnityEngine;

public class OutlineActivation : MonoBehaviour
{
    [SerializeField] private Outline outline;
    [SerializeField] private Color colorOn;
    [SerializeField] private Color colorOff;
    public bool IsColorOn => colorOn == outline.OutlineColor;

    public OutlineActivation EnableOutline() 
    {
        outline.OutlineColor = colorOn;

        return this;
    }

    public void DisableLastOutline() 
    {
        outline.OutlineColor = colorOff;
    }
}
