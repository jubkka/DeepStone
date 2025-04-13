using UnityEngine;

public class ChestInteractable : Interactable
{
    [SerializeField] private ToggleInventory inventory;
    [SerializeField] private CanvasGroup canvasGroup;
    
    //private ChestInteractManager chestInteractManager;
    private ChestComponent chest;
    private ChestContainer chestContainer;
    private Animation anim;
    
    private bool isOpen = false;

    private void Start()
    {
        chest = GameSystems.Instance.GetChestComponent;
        
        anim = GetComponentInParent<Animation>();
        chestContainer = GetComponent<ChestContainer>();
        
        inventory.OnInventoryClosed += Close;
    }
    
    public override void Interact()
    {
        if (canvasGroup.alpha == 0f)
            Open();
        else
            Close();
        
        inventory.Toggle();
    }

    private void Open()
    {
        ChangeState(true);
        chest.GiveItems(chestContainer.Items);
        anim.Play("Opening");
    }

    private void Close()
    {
        if (!isOpen)
            return;
        
        ChangeState(false);
        chestContainer.Items = chest.TakeItems();
        anim.Play("Closing");
    }

    private void ChangeState(bool state)
    {
        canvasGroup.alpha = state ? 1f : 0f;
        canvasGroup.blocksRaycasts = canvasGroup.alpha == 1f;
        isOpen = state;
    }
}