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
    }

    public override void Interact()
    {
        if (canvasGroup.alpha == 1)
            Close();
        else
            Open();

        inventory.Toggle();
    }

    private void Open() 
    {
        anim.Play("Opening");

        canvasGroup.alpha = 1;
    }

    private void Close() 
    {
        anim.Play("Closing");

        canvasGroup.alpha = 0;
    }
}