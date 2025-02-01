using UnityEngine;

public class InventoryUICompontn : MonoBehaviour
{
    [SerializeField] private InventoryComponent inventory;
    [SerializeField] private Transform slotsParent;
    [SerializeField] private GameObject itemUIPrefab;
    [SerializeField] private ItemUI[] itemUIs = new ItemUI[20];
    [SerializeField] private Transform dragContainer;

    private void Start() 
    {
        inventory.onInventoryChanged += UpdateSlotUI;

        for (int i = 0; i < itemUIs.Length; i++)
        {
            if (!inventory.items[i].IsEmpty) AddSlotUI(i);
        }
    }

    private void AddSlotUI(int index) 
    {
        GameObject iconUI = Instantiate(itemUIPrefab, slotsParent.GetChild(index));
        ItemUI itemUI = iconUI.GetComponent<ItemUI>();

        itemUI.dragContainer = dragContainer;

        itemUIs[index] = itemUI;
        itemUI.Setup(inventory.items[index], index, inventory);
    }

    private void RemoveSlotUI(int index) 
    {
        if (itemUIs[index] == null) return;

        Destroy(itemUIs[index].gameObject);
        itemUIs[index] = null;
    }

    private void UpdateSlotUI(int index)
    {
        if (index < 0 || index >= itemUIs.Length) return;

        if (inventory.items[index].IsEmpty) RemoveSlotUI(index);
        else if (itemUIs[index] == null) AddSlotUI(index);
        else itemUIs[index].Setup(inventory.items[index], index, inventory);
    }


}
