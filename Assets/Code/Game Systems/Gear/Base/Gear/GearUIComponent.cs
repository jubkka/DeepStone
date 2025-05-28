using UnityEngine;

public class GearUIComponent : MonoBehaviour
{
    [SerializeField] private GameObject itemUIPrefab;
    
    private Transform dragContainer;
    private GearComponent gear;
    private Transform slotsParent;
    private BaseItemUI[] itemUIs;

    public void Initialize(GearComponent newGear)
    {
        gear = newGear;
        slotsParent = transform.Find("Slots");
        dragContainer = GameObject.FindWithTag("DragContainer").transform;
        
        itemUIs = new BaseItemUI[newGear.GetSize];

        newGear.OnItemChanged += UpdateSlotUI;
    }

    private void AddSlotUI(int index) 
    {
        BaseItemUI itemUI = Instantiate(itemUIPrefab, slotsParent.GetChild(index)).GetComponent<BaseItemUI>();
        
        itemUIs[index] = itemUI;
        itemUI.Initialize(gear.GetItem(index), index, gear, dragContainer);
    }

    private void RemoveSlotUI(int index) 
    {
        if (itemUIs[index] == null) 
            return;

        Destroy(itemUIs[index].gameObject);
        itemUIs[index] = null;
    }
    
    private void UpdateSlotUI(int index)
    {
        Item item = gear.GetItem(index);

        if (item.IsEmpty) 
            RemoveSlotUI(index);
        else 
        {
            if (itemUIs[index] == null) AddSlotUI(index);
            else itemUIs[index].Initialize(item, index, gear, dragContainer);
        }
    }
}