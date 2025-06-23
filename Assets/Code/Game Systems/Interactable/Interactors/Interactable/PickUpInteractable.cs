using UnityEngine;

public class PickUpInteractable : Interactable
{
    [SerializeField] private GameObject objectParent;
    [SerializeField] private GenericContainer container;
        
    private InventoryComponent inventory;

    public override void Interact()
    {
        AddItem(container);
        
        SFXAudioManager.Instance.PlaySound("PickUp");
    }

    private void AddItem(GenericContainer itemContainer) 
    {
        if (inventory == null)
            inventory = GearSystems.Instance.Inventory;
        
        if (inventory.AddItem(itemContainer.GetItem, 0))
            Destroy(objectParent);
    }
}
