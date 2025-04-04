using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HandComponent : MonoBehaviour
{
    [SerializeField] private Transform handContainer;
    [SerializeField] private HotbarInputControl inputControl;
    [SerializeField] private DropManager dropManager;
    
    private HotbarComponent hotbar;

    private GameObject activeItemGameObject;
    private Item activeItem = new Item();
    public Item GetActiveItem => activeItem;
    public GameObject GetActiveItemGameObject => activeItemGameObject;
    
    public event Action<Item> OnActiveItemChanged; 

    private void Start()
    {
        hotbar = GameSystems.Instance.GetHotbarComponent;
        
        inputControl.OnActiveSlotChanged += PutInHandByIndex;
        dropManager.OnItemDropped += PutInHand;
        
        PutInHandByIndex(inputControl.ActiveSlotIndex);
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
        
        if(handContainer.childCount > 0) 
            Destroy(handContainer.GetChild(0).gameObject);

        if (activeItem.data != null)
        {
            SpawnItem();
            CreateItem(item);
            
            OnActiveItemChanged?.Invoke(activeItem);
        }
    }
    
    public virtual void UseItemInHand()
    {
        if (activeItem.data != null)
            activeItem.Use(ItemSlotType.Hotbar);
    }

    private void SpawnItem()
    {
        activeItemGameObject = Instantiate(activeItem.data.GetPrefab, handContainer);
        activeItemGameObject.layer = LayerMask.NameToLayer("WeaponCamera");
    }

    private void CreateItem(Item item)
    {
        ItemContainer itemContainer = activeItemGameObject.GetComponentInChildren<ItemContainer>();
        itemContainer?.CreateNewItem(item);
    }
}