using UnityEngine;

public class ChestInteractable : Interactable
{
    private ChestInput chestInput;
    private Animation anim;
    public ChestContainer ChestContainer { get; private set; }
    
    private void Start()
    {
        anim = GetComponentInParent<Animation>();
        ChestContainer = GetComponent<ChestContainer>();
    }

    public void Init(ChestInput input)
    {
        chestInput = input;
    }

    public override void Interact()
    {
        Open();
    }

    private void Open()
    {
        chestInput.OpenChest(this);
        //anim.Play("Opening"); //TODO анимации
    }

    public void SaveBackItems(Item[] items)
    {
        ChestContainer.Items = items;

        //anim.Play("Closing");
    }
}