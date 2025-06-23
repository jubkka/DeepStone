using System.Linq;
using UnityEngine;

public class ChestInteractable : Interactable
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource sound;
    [SerializeField] private SoundData openChestSound;
    [SerializeField] private SoundData closeChestSound;
    public ChestContainer ChestContainer { get; private set; }
    
    private void Start()
    {
        ChestContainer = GetComponent<ChestContainer>();
    }

    public override void Interact()
    {
        Open();
    }

    private void Open()
    {
        ChestInput chestInput = GameObject.FindWithTag("ChestInput").GetComponentInChildren<ChestInput>();
        
        chestInput.OpenChest(this);
        sound.PlayOneShot(openChestSound.AudioClip, openChestSound.Volume);
        
        anim.Play("Open");
    }

    public void SaveBackItems(Item[] items)
    {
        ChestContainer.Items = items.ToList();
        
        sound.PlayOneShot(closeChestSound.AudioClip, closeChestSound.Volume);
        
        anim.Play("Close");
    }
}