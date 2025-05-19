using UnityEngine;

public class HandManager : MonoBehaviour
{
    [SerializeField] private RightHandComponent rightHand;
    [SerializeField] private LeftHandComponent leftHand;
    [SerializeField] private MagicHandComponent magicHand;
    
    private HotbarComponent hotbar;
    private HotbarInput hotbarInput;
    private DropComponent dropComponent;

    private HandEquipContext handEquipContext;
    
    private void Start()
    {
        hotbar = GearSystems.Instance.Hotbar;
        hotbarInput = InputSystems.Instance.GetHotbarInput;
        handEquipContext = new HandEquipContext(rightHand, leftHand, magicHand);
        
        hotbarInput.OnKeyPressed += OnSlotSelected;
        
        OnSlotSelected(hotbarInput.ActiveSlotIndex);
    }

    private void OnSlotSelected(int slotIndex)
    {
        var item = hotbar.GetItem(slotIndex);

        item.data?.TryEquip(handEquipContext, item);
    }
}