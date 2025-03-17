using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private float duration;
    private Transform door;
    private Coroutine coroutine;

    private void Start()
    {  
       door = transform.parent; 
    }

    public void Open()
    {
        if (coroutine == null)
            coroutine = StartCoroutine(SmoothMovementDoor(90));
    }

    public void Close() 
    {
        if (coroutine == null)
            coroutine = StartCoroutine(SmoothMovementDoor(-90));
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