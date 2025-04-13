using QuickOutline;
using UnityEngine;

public class OutlineActivation : MonoBehaviour
{
    [SerializeField] private Color colorOn;
    [SerializeField] private Color colorOff;
    public bool IsColorOn => colorOn == outline.OutlineColor;
    private Outline outline;

    private void Awake()
    {
        outline = GetComponentInParent<Outline>();
    }

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
