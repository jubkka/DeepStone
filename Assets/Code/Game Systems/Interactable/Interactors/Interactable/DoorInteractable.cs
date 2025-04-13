using System.Collections;
using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] private float duration;
    private BoxCollider boxCollider;
    private Transform door;
    private Coroutine coroutine;

    private void Start()
    {  
       door = transform.parent; 
       boxCollider = transform.parent.GetComponent<BoxCollider>();
    }

    public override void Interact()
    {
        if (coroutine == null)
        {
            float targetAngle = transform.rotation.y > 0 ? -90f : 90f;
            boxCollider.enabled = transform.rotation.y > 0 ? true : false;

            coroutine = StartCoroutine(SmoothMovementDoor(targetAngle));
        }
    }
    
    public IEnumerator SmoothMovementDoor(float targetAngle)
    {
        Quaternion startRotation = door.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(0, startRotation.eulerAngles.y + targetAngle, 0);
        float timeElapsed = 0f;

        while (timeElapsed < duration) 
        {
            door.transform.rotation = Quaternion.Lerp(startRotation, endRotation, timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        door.transform.rotation = endRotation;
        coroutine = null;
    }
}