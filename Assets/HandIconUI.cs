using UnityEngine;
using UnityEngine.UI;

public class HandIconUI : MonoBehaviour
{
    [SerializeField] private Image itemInHandIcon;

    private Item item;
    
    private RightHandComponent rightHand;
    private LeftHandComponent leftHand;
    private MagicHandComponent magicHand;
    
    bool isInitialized = false;

    public void Init(Item newItem)
    {
        item = newItem;
        
        if (isInitialized)
            return;
        
        rightHand = CombatSystems.Instance.RightHand;
        leftHand = CombatSystems.Instance.LeftHand;
        magicHand = CombatSystems.Instance.MagicHand;
        
        rightHand.OnActiveItemChanged += OnHandItemChanged;
        leftHand.OnActiveItemChanged += OnHandItemChanged;
        magicHand.OnActiveItemChanged += OnHandItemChanged;

        OnHandItemChanged(rightHand.GetActiveItem);
        OnHandItemChanged(leftHand.GetActiveItem);
        OnHandItemChanged(magicHand.GetActiveItem);
        
        isInitialized = true;
    }
    
    private void OnDestroy()
    {
        rightHand.OnActiveItemChanged -= OnHandItemChanged;
        leftHand.OnActiveItemChanged -= OnHandItemChanged;
        magicHand.OnActiveItemChanged -= OnHandItemChanged;
    }
    
    public void OnHandItemChanged(Item itemHand)
    {
        if (itemHand.GetUniqueId == item.GetUniqueId)
            itemInHandIcon.enabled = true;
        else
            itemInHandIcon.enabled = false;
    }
}
