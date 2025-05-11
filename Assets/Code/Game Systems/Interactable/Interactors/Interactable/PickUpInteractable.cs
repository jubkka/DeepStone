using UnityEngine;

public class PickUpInteractable : Interactable
{
    private GameObject itemObj;

    private void Awake()
    {
        itemObj = transform.parent.gameObject;
    }

    public override void Interact()
    {
        ItemContainer itemContainer = GetComponentInChildren<ItemContainer>();
        
        if (itemContainer != null)
            AddItem(itemContainer);
    }

    private void AddItem(ItemContainer itemContainer) 
    {
        InventoryComponent inventory = GearSystems.Instance.GetInventoryComponent;

        if (inventory.AddItem(itemContainer.GetItem, 0))
            Destroy(itemObj);
    }
}
