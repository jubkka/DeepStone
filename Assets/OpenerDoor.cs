using UnityEngine;

public class OpenerDoor : MonoBehaviour
{
    [SerializeField] LayerMask doorMask;
    private void Update()
    {
        if (Physics.SphereCast(transform.position, 0.25f, transform.forward, out RaycastHit hit, 2f, doorMask))
        {
            OpenDoor(hit.collider?.gameObject);
        }
    }

    private void OpenDoor(GameObject door)
    {
        DoorInteractable doorInteractable = door.GetComponentInChildren<DoorInteractable>();
        doorInteractable?.Interact();
    }
}
