using UnityEngine;

public class HandComponent : MonoBehaviour
{
    [SerializeField] private Transform handContainer;
    
    private HotbarComponent hotbar;
    [SerializeField] private HotbarInputControl inputControl;
    
    private Item activeItem = new Item();
    public Item ActiveItem => activeItem;

    private void Start()
    {
        hotbar = GameSystems.Instance.GetHotbarComponent;
        
        inputControl.OnActiveSlotChanged += PutInHandByIndex;
    }

    private void PutInHandByIndex(int index)
    {
        if (inputControl.ActiveSlotIndex == index) 
            PutInHand(hotbar.GetItem(index));
    }

    public virtual void PutInHand(Item item)
    {
        activeItem = item;
        
        if(handContainer.childCount > 0) 
            Destroy(handContainer.GetChild(0).gameObject);

        if (activeItem.data != null)
        {
            GameObject newItem = Instantiate(activeItem.data.GetPrefab, handContainer);
            newItem.layer = LayerMask.NameToLayer("WeaponCamera");
            
            ItemContainer itemContainer = newItem.GetComponentInChildren<ItemContainer>();
            
            itemContainer.CreateNewItem(item);
        }
    }
    
    public virtual void UseItemInHand()
    {
        if (activeItem.data != null)
            activeItem.Use(ItemSlotType.Hotbar);
    }
}