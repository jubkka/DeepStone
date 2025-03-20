using UnityEngine;

public class PickUpInteractor : Interactor
{
    private GameObject itemObj;

    private void Awake()
    {
        itemObj = transform.parent.gameObject;
    }

    public override void Interact()
    {
        ItemContainer itemContainer = GetComponent<ItemContainer>();

        AddItem(itemContainer);
    }

    private void AddItem(ItemContainer itemContainer) 
    {
        InventoryComponent inventory = InventoryComponent.Instance;

        if (inventory.AddItem(itemContainer.GetItem))
            Destroy(itemObj);
    }
}
