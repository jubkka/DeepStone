using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (!eventData.pointerDrag.TryGetComponent(out BaseItemUI droppedItemUI)) return;

        droppedItemUI.Drop();
    }
}