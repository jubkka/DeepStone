using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InteractRay interactRay;
    [SerializeField] private InventoryComponent inventory;
    [SerializeField] private LayerMask layerMask;

    [Header("Properties")]
    [SerializeField] private float distance;
    [SerializeField] private KeyCode pickUpKey;

    private void Awake()
    {
        pickUpKey = InputManager.GetKey("PickUp");
        interactRay.Distance = distance;
    }
    private void Update()
    {
        TryPickUp();
    }

    private void TryPickUp() 
    {
        GameObject obj = interactRay.Cast(layerMask);
        interactRay.DrawOutline(obj);

        if (obj == null) return;
            
        if (obj.TryGetComponent(out ItemContainer itemContainer)) 
        {
            if (Input.GetKeyDown(pickUpKey)) TryPickUpItem(itemContainer, obj);
        }
    }

    private void TryPickUpItem(ItemContainer itemContainer, GameObject obj) 
    {
        if (inventory.AddItem(itemContainer.item)) Destroy(obj);
    }
}
