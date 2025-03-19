using UnityEngine;

public class DoorInteractor : Interactor
{
    [SerializeField] private InteractRay interactRay;
    [SerializeField] private LayerMask layerMask;

    public override void Interact()
    {
        GameObject obj = interactRay.Cast(layerMask);

        if (obj == null) return;

        DoorController doorController = obj.GetComponentInChildren<DoorController>();

        if (doorController != null) 
        {
            doorController.Interact();
        }
    }
}