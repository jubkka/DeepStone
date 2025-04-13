using UnityEngine;

public class GearUIComponent : MonoBehaviour
{
    [SerializeField] protected GameObject itemUIPrefab;
    
    protected Transform dragContainer;
    protected GearComponent gear;
    protected Transform slotsParent;
    protected BaseItemUI[] itemUIs;

    public virtual void Initialize(GearComponent gear)
    {
        slotsParent = transform.Find("Slots");
        dragContainer = GameObject.FindWithTag("DragContainer").transform;
        
        itemUIs = new BaseItemUI[gear.maxSize];

        this.gear = gear;
        gear.OnItemChanged += UpdateSlotUI;
    }

    protected void AddSlotUI(int index) 
    {
        BaseItemUI itemUI = Instantiate(itemUIPrefab, slotsParent.GetChild(index)).GetComponent<BaseItemUI>();

        itemUI.dragContainer = dragContainer;
        itemUI.gear = gear;
        itemUIs[index] = itemUI;
        itemUI.Initialize(gear.GetItem(index), index);
    }

    protected void RemoveSlotUI(int index) 
    {
        if (itemUIs[index] == null) 
            return;

        Destroy(itemUIs[index].gameObject);
        itemUIs[index] = null;
    }
    public void UpdateSlotUI(int index)
    {
        Item item = gear.GetItem(index);

        if (item.IsEmpty) 
            RemoveSlotUI(index);
        else 
        {
            if (itemUIs[index] == null) AddSlotUI(index);
            else itemUIs[index].Initialize(item, index);
        }
    }
}