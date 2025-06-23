using System;
using UnityEngine;

public abstract class HandComponent : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected Transform handContainer;
    [SerializeField] protected DropComponent dropComponent;
    
    [Header("Item")]
    [SerializeField] protected Item activeItem = new Item();
    [SerializeField] private GameObject activeItemGameObject;
    
    public Item GetActiveItem => activeItem;
    public GameObject GetActiveItemGameObject => activeItemGameObject;
    public event Action<Item> OnActiveItemChanged; 

    public void Init()
    {
        dropComponent.OnItemDropped += DropItemFromHand; //TODO Зачем это ?
    }
    
    public virtual void PutInHand(Item item)
    {
        activeItem = activeItem.GetUniqueId == item.GetUniqueId ? new Item() : item;

        DestroyGameObject();

        if (activeItem.data != null)
        {
            SpawnItem();
            CreateItem(item);
        }

        OnActiveItemChanged?.Invoke(activeItem);
    }

    protected void DropItemFromHand(Item item)
    {
        if (item.GetUniqueId != activeItem.GetUniqueId)
            return;
        
        DestroyGameObject();
        
        activeItem = new Item();
        OnActiveItemChanged?.Invoke(activeItem);
    }

    protected void DestroyGameObject()
    {
        foreach (Transform child in handContainer)
            Destroy(child.gameObject);
    }

    public void UseItemInHand()
    {
        if (activeItem.data != null)
            activeItem.Use(ItemSlotType.Hotbar);

        if (activeItem.Amount <= 0)
            ClearHand();
    }
    
    public void ClearHand()
    {
        if (activeItem.data != null)
        {
            DestroyGameObject();
            activeItem = new Item();
            
            OnActiveItemChanged?.Invoke(activeItem);
        }
    }

    protected void SpawnItem()
    {
        activeItemGameObject = Instantiate(activeItem.data.GetPrefab, handContainer);
        activeItemGameObject.layer = LayerMask.NameToLayer("Weapon");
        activeItemGameObject.GetComponentInChildren<CorrectTransform>()?.SetupHand();
        activeItemGameObject.GetComponentInChildren<InfoPanelWorldSpace>()?.gameObject.SetActive(false);
    }

    protected void CreateItem(Item item)
    {
        GenericContainer itemContainer = activeItemGameObject.GetComponentInChildren<GenericContainer>();
        itemContainer?.CreateNewItem(item);
    }
}