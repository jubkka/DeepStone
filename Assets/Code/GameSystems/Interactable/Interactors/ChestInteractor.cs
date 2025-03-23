using UnityEngine;

public class ChestInteractor : Interactor
{
    [SerializeField] private ToggleInventory inventory;
    private ChestContainer chestContainer;
    private ChestComponent chest;
    private CanvasGroup canvasGroup;
    private Animation anim;

    private void Start()
    {
        anim = GetComponentInParent<Animation>();
        chest = ChestComponent.Instance;
        chestContainer = GetComponent<ChestContainer>();
        canvasGroup = chest.GetComponentInParent<CanvasGroup>();

        InputManager.Instance.OnInventoryPressed += Close;
    }

    public override void Interact()
    {
        if (canvasGroup.alpha == 1)
        {
            Close();
            chestContainer.Items = chest.TakeItems();
            canvasGroup.blocksRaycasts = canvasGroup.alpha == 1;
            anim.Play("Closing");
        }
        else
        {
            Open();
            chest.GiveItems(chestContainer.Items);
            canvasGroup.blocksRaycasts = canvasGroup.alpha == 1;
            anim.Play("Opening");
        }
        
        inventory.Toggle();
    }

    private void Open() 
    {
        canvasGroup.alpha = 1;
    }

    private void Close() 
    {
        canvasGroup.alpha = 0;
    }
}