using UnityEngine;

public abstract class GearUIComponent : MonoBehaviour
{
    [SerializeField] protected GearComponent gear;
    [SerializeField] protected Transform slotsParent;
    [SerializeField] protected Transform dragContainer;
    [SerializeField] protected GameObject itemUIPrefab;
    [SerializeField] protected BaseItemUI[] itemUIs;

    public virtual void Initialize()
    {
        itemUIs = new BaseItemUI[gear.maxSize];

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
        if (itemUIs[index] == null) return;

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