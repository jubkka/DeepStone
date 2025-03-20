using UnityEngine;

public class InteractorController : MonoBehaviour
{
    [SerializeField] private float interactDistance = 2.5f;
    [SerializeField] private LayerMask interactableMask;
    [SerializeField] private InteractRay interactRay;

    private void Start()
    {
        InputManager.Instance.OnInteractPressed += TryInteract; 
    }

    private void Update()
    {
        interactRay.DrawRay(interactDistance);
    }

    private void TryInteract() 
    {
        GameObject obj = interactRay.Cast(interactableMask, interactDistance);

        if (obj == null) return;

        Interactor interactable = obj.GetComponentInChildren<Interactor>();

        if (interactable != null)
            interactable.Interact();
    }
}