using UnityEngine;
using UnityEngine.InputSystem;

public class InteractorInput : InputControl
{
    private Transform cam;
    private float distance;
    
    protected override void Start()
    {
        cam = Camera.main.transform;
        distance = Raycaster.Rays[RaysType.Interact];
        
        base.Start();
    }
    
    protected override void SubscribeToControls()
    {
        controls.Player.Interact.performed += OnInteract;
        controls.Player.Enable();
    }

    protected override void UnsubscribeFromControls()
    {
        controls.Player.Interact.performed -= OnInteract;
        controls.Player.Disable();
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        TryInteract();
    }

    private void TryInteract()
    {
        if (!Raycaster.Cast(cam.position, cam.forward, distance, out GameObject hitObject))
            return;

        Interactable interactable = hitObject?.GetComponentInChildren<Interactable>();

        if (interactable != null)
            interactable.Interact();
    }
}