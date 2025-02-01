using UnityEngine;
using UnityEngine.EventSystems;

public class DropItemUI : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        GameObject droppedItem = eventData.pointerDrag;
        droppedItem.GetComponent<ItemUI>().afterDragParent = transform;
    }
}
