using UnityEngine;

public class InteractorController : MonoBehaviour
{
    private Transform cam;
    private float distance;
    private Color color;

    private void Start()
    {
        InputManager.Instance.OnInteractPressed += TryInteract; 
        
        cam = Camera.main.transform;
        distance = Raycaster.Rays[RaysType.Interact];
        
        color = Color.green;
    }

    private void Update()
    {
        Raycaster.DrawRay(cam.position, cam.forward * distance, color);
    }

    private void TryInteract()
    {
        if (!Raycaster.Cast(cam.position, cam.forward, distance, out GameObject hitObject))
            return;

        Interactable interactable = hitObject.GetComponentInChildren<Interactable>();

        if (interactable != null)
            interactable.Interact();
    }
}