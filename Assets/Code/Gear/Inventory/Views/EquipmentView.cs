using UnityEngine;

public class EquipmentView : GearView
{
    [SerializeField] private EquipmentPresenter equipmentPresenter;
    
    public void WearArmor(string slotEquipment, ItemView item) 
    {
        switch (slotEquipment)
        {
            case "Helmet":
                PutInSlot(item, 0);
            break;
            
            case "Chestplate":
                PutInSlot(item, 1);
            break;
        }
    }

    public void TakeOffArmor(string slotEquipment) 
    {
        switch (slotEquipment)
        {
            case "Helmet":
                PullOutSlot(0);
            break;
            
            case "Chestplate":
                PullOutSlot(1);
            break;
        }
    }

    private void PutInSlot(ItemView item, int i) 
    {
        Transform slots = transform.GetChild(i);
        
        GameObject icon = slots.GetChild(i).GetChild(0).gameObject; 
        icon.SetActive(false);

        item.transform.SetParent(slots.GetChild(i));
        item.transform.position = slots.GetChild(i).position;
    }

    private void PullOutSlot(int armorIndex) 
    {
        
    }
}