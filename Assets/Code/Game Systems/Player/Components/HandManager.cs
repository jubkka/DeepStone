using UnityEngine;

public class HandManager : MonoBehaviour
{
    [Header("Hotbar Components")]
    [SerializeField] private HotbarComponent hotbar;
    [SerializeField] private HotbarInput hotbarInput;
    
    [Header("Hands")]
    [SerializeField] private RightHandComponent rightHand;
    [SerializeField] private LeftHandComponent leftHand;
    [SerializeField] private MagicHandComponent magicHand;

    private HandEquipContext handEquipContext;
    
    private void Start()
    {
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