using UnityEngine;

public class InteractorController : MonoBehaviour
{
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private Raycaster interactRay;
    private Transform cameraPosition;
    private float interactDistance;

    private void Start()
    {
        InputManager.Instance.OnInteractPressed += TryInteract; 
        cameraPosition = Camera.main.transform;
        interactDistance = Raycaster.Rays["Interact"];
    }

    private void Update()
    {
        interactRay.DrawRay(interactDistance);
    }

    private void TryInteract() 
    {
        GameObject obj = interactRay.Cast(cameraPosition, interactableMask, interactDistance);

        if (obj == null) return;

        Interactor interactable = obj.GetComponentInChildren<Interactor>();

        if (interactable != null)
            interactable.Interact();
    }
}