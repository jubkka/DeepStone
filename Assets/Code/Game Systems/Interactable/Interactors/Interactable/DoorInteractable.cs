using System.Collections;
using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] private float duration;
    
    [Header("Components")]
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Transform pivot;
    
    private Coroutine coroutine;
    private GameObject player;

    private bool isOpen = false;
    private bool blockInteract = false;

    private Vector3 startRotation;
    private Vector3 forward;

    private Quaternion start;
    private Quaternion target;

    private void Start()
    { 
        start = pivot.rotation;
        player = GameObject.FindWithTag("Player");
    }
    
    private void Close()
    {
        StartCoroutine(DoRotation(pivot.rotation, start));
    }

    private void Open()
    {
        float dot = GetDot();

        float angle = (dot <= 0) ? -90f : 90f;
        
        target = Quaternion.Euler(0f, start.eulerAngles.y + angle, 0f);
        
        coroutine = StartCoroutine(DoRotation(pivot.rotation, target));
    }

    private IEnumerator DoRotation(Quaternion start, Quaternion end)
    {
        float timer = 0;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            
            pivot.rotation = Quaternion.Slerp(start, end, timer / duration);
            yield return null;
        }

        blockInteract = false;
        coroutine = null;
    }

    public override void Interact()
    {
        if (blockInteract)
            return;
        
        if (isOpen)
            Close();
        else
            Open();
        
        ToggleStates();
    }

    private void ToggleStates()
    {
        boxCollider.enabled = isOpen;
        isOpen = !isOpen;
        blockInteract = true;
    }

    private float GetDot()
    {
        Vector3 toPlayer = (player.transform.position - pivot.transform.position).normalized;
        return Vector3.Dot(pivot.right, toPlayer);
    }
}