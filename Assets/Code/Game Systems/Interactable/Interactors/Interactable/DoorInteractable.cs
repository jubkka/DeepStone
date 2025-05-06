using DG.Tweening;
using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] private float duration;
    
    private BoxCollider boxCollider;
    private Transform door;
    private Coroutine coroutine;

    private GameObject player;

    private bool isOpen = false;

    private void Start()
    {  
       door = transform.parent; 
       boxCollider = door.GetComponent<BoxCollider>();
       
       player = GameObject.FindWithTag("Player");
    }

    public override void Interact()
    {
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        float dot = GetDot();
        float rotate = GetRotate(dot);

        Rotate(rotate);
        ToggleStates();
    }

    private void ToggleStates()
    {
        boxCollider.enabled = isOpen;
        isOpen = !isOpen;
    }

    private void Rotate(float rotate) => door.transform.DOLocalRotate(new Vector3(0, rotate, 0), duration);

    private float GetRotate(float dot)
    {
        float rotationDirection = isOpen ? -90 : 90;
        float localAngle = door.transform.localEulerAngles.y;
        
        return dot > 0 ? 
            localAngle + rotationDirection :
            localAngle - rotationDirection;
    }

    private float GetDot()
    {
        Vector3 toPlayer = (player.transform.position - door.transform.position).normalized;
        return Vector3.Dot(door.transform.right, toPlayer);
    }
}