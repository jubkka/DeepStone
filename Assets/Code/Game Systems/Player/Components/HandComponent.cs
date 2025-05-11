using System;
using UnityEngine;

public class HandComponent : MonoBehaviour
{
    [SerializeField] private Transform handContainer;
    [SerializeField] private HotbarInput input;
    [SerializeField] private DropManager dropManager;
    
    private HotbarComponent hotbar;

    private GameObject activeItemGameObject;
    private Item activeItem = new Item();
    public Item GetActiveItem => activeItem;
    public GameObject GetActiveItemGameObject => activeItemGameObject;
    
    public event Action<Item> OnActiveItemChanged; 

    private void Start()
    {
        hotbar = GearSystems.Instance.GetHotbarComponent;
        
        input.OnActiveSlotChanged += PutInHandByIndex;
        dropManager.OnItemDropped += DropItemInHand;
        
        PutInHandByIndex(input.ActiveSlotIndex);
    }

    private void PutInHandByIndex(int index)
    {
        Item item = hotbar.GetItem(index);
        
        if (activeItem == item)
            return;
            
        PutInHand(item);
    }

    public virtual void PutInHand(Item item)
    {
        activeItem = item;

        DestroyGameObject();

        if (activeItem.data != null)
        {
            SpawnItem();
            CreateItem(item);
        }
        
        OnActiveItemChanged?.Invoke(activeItem);
    }

    private void DropItemInHand(Item item)
    {
        if (item != activeItem)
            return;
        
        DestroyGameObject();
        
        activeItem = new Item();
        OnActiveItemChanged?.Invoke(activeItem);
    }

    private void DestroyGameObject()
    {
        if(handContainer.childCount > 0) 
            Destroy(handContainer.GetChild(0).gameObject);
    }

    public virtual void UseItemInHand()
    {
        if (activeItem.data != null)
            activeItem.Use(ItemSlotType.Hotbar);
    }

    private void SpawnItem()
    {
        activeItemGameObject = Instantiate(activeItem.data.GetPrefab, handContainer);
        activeItemGameObject.layer = LayerMask.NameToLayer("Weapon");
    }

    private void CreateItem(Item item)
    {
        ItemContainer itemContainer = activeItemGameObject.GetComponentInChildren<ItemContainer>();
        itemContainer?.CreateNewItem(item);
    }
}