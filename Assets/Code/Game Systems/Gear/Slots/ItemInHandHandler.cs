using System;
using UnityEngine;

public class ItemInHandHandler : MonoBehaviour
{
    [SerializeField] private Transform slots;
    
    private InventoryComponent inventory;
    private HandComponent hand;
    
    private void Start()
    {
        InputSystems.Instance.GetHotbarInput.OnActiveSlotChanged += MoveIcon;
        
        inventory = GearSystems.Instance.GetInventoryComponent;
        hand = CombatSystems.Instance.GetHandComponent;
    }

    private void MoveIcon(int slotIndex)
    {
        Item itemInHand = hand.GetActiveItem;

        for (int i = 0; i < inventory.GetStorage.Items.Length - 1; i++)
        {
            Item item = inventory.GetStorage.Items[i];
            
            if (item.data == null)
                continue;
            
            if (itemInHand.GetUniqueId == item.GetUniqueId)
            {
                Transform nextSlot = slots.GetChild(i);
        
                gameObject.SetActive(true);
                transform.SetParent(nextSlot);
                transform.position = nextSlot.position;

                return;
            }
        }

        HideIcon();
    }
    
    public void HideIcon()
    {
        gameObject.SetActive(false);
    }
}