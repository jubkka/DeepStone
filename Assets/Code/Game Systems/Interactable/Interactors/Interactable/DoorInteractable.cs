using System.Collections;
using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] private float duration;
    
    [Header("Components")]
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Transform pivot;
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundData doorSound;
    
    private GameObject player;

    private bool isOpen = false;
    private bool blockInteract = false;

    private Vector3 startRotation;
    private Vector3 forward;

    private Quaternion startRot;
    private Quaternion target;

    private void Start()
    { 
        startRot = pivot.rotation;
    }
    
    private void Close()
    {
        StartCoroutine(DoRotation(pivot.rotation, startRot));
    }

    private void Open()
    {
        float dot = GetDot();

        float angle = (dot <= 0) ? -90f : 90f;
        
        target = Quaternion.Euler(0f, startRot.eulerAngles.y + angle, 0f);
        
        StartCoroutine(DoRotation(pivot.rotation, target));
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
    }

    public override void Interact()
    {
        if (blockInteract)
            return;
        
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        
        if (isOpen)
            Close();
        else
            Open();
        
        ToggleStates();
        audioSource.PlayOneShot(doorSound.AudioClip, doorSound.Volume);
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