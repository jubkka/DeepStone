using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI TMP;
    [SerializeField] private Image icon;
    [SerializeField] private InventoryComponent inventory;
    [SerializeField] private int index;

    //Drag&Drop
    public Transform beforeDragParent;
    public Transform afterDragParent;
    public Transform dragContainer;


    //Устанавливаем кол-во и иконку предмета
    public void Setup(ItemSlot itemSlot, int index, InventoryComponent inventory) 
    {
        if (itemSlot.IsEmpty) return;

        this.index = index;
        this.inventory = inventory;

        icon.sprite = itemSlot.item.GetIcon;
        TMP.text = itemSlot.item.IsStackable ? itemSlot.amount.ToString() : "";
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        icon.raycastTarget = false;
        icon.color = new Color(255,255,255, 0.85f);

        beforeDragParent = transform.parent;
        transform.SetParent(dragContainer);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        icon.raycastTarget = true;
        icon.color = new Color(255,255,255, 1f);

        Transform targetParent = beforeDragParent;
        int targetIndex = index;

        if (afterDragParent != null)
        {
            targetIndex = afterDragParent.GetSiblingIndex();
            targetParent = afterDragParent;
        }

        if (inventory.MoveItems(index, targetIndex))
        {
            SetTransformParent(targetParent);
            index = targetIndex;
        }
        else
        {
            SetTransformParent(beforeDragParent);
        }

        afterDragParent = null;
    }

    private void SetTransformParent(Transform newParent)
    {
        transform.SetParent(newParent);
        transform.position = newParent.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right) Debug.Log(inventory.items[index].Use());
    }
}