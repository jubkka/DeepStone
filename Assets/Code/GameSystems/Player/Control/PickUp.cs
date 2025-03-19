using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private InteractRay interactRay;
    [SerializeField] private InventoryComponent inventory;
    [SerializeField] private LayerMask layerMask;

    public void TryPickUp() 
    {
        GameObject obj = interactRay.Cast(layerMask);

        TryPickUpItem(obj);
    }

    private void TryPickUpItem(GameObject obj) 
    {
        if (obj == null) return;
            
        if (obj.TryGetComponent(out ItemContainer itemContainer)) 
        {
            if (inventory.AddItem(itemContainer.item)) Destroy(obj);   
        }
    }
}
