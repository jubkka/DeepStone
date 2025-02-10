using UnityEngine;
using UnityEngine.EventSystems;


public class EquipmentItemUI : BaseItemUI
{
    [SerializeField] private GameObject equipmentIcon;

    public override void Initialize(Item item, int index)
    {
        gear.OnEquipmentChanged += ChangeStateEquipmentIcon;

        equipmentIcon = transform.parent.GetChild(0).gameObject;

        base.Initialize(item, index);
    }
    
    public override void OnBeginDrag(PointerEventData eventData)
    {
        ChangeStateEquipmentIcon(true);

        base.OnBeginDrag(eventData);
    }

    public override void OnEndDrag(PointerEventData eventData) 
    {
        ChangeStateEquipmentIcon(false);

        base.OnEndDrag(eventData);
    }
    private void ChangeStateEquipmentIcon(bool state) => equipmentIcon.SetActive(state);

    public override void HandleDrop(GearComponent targetGear)
    {
        if (!afterDragParent.TryGetComponent(out SlotUI slot)) return;

        int targetIndex = afterDragParent.GetSiblingIndex();

        if (slot.slotType == SlotType.Inventory) 
        {
            targetGear.AddItem(item, targetIndex);

            gear.OnEquipmentChanged -= ChangeStateEquipmentIcon;

            gear.RemoveItem(index);
        } 
    }

}