using UnityEngine;

public class SpellCastingComponent : MonoBehaviour
{
    [Header("Magic Hand Component")]
    [SerializeField] private GameObject magicItem;
    [SerializeField] private Animator animator;
    
    private RightHandComponent rightHand;
    private LeftHandComponent leftHand;
    private MagicHandComponent magicHand;

    private void Start()
    {
        rightHand = CombatSystems.Instance.GetRightHand;
        leftHand = CombatSystems.Instance.GetLeftHand;
        magicHand = CombatSystems.Instance.GetMagicHand;

        magicHand.OnActiveItemChanged += GetComponents;
    }

    private void GetComponents(Item item)
    {
        if (item.data == null)
            return;

        magicItem = magicHand.GetActiveItemGameObject;
        animator = magicItem.GetComponent<Animator>();
    }

    public void Cast()
    {
        if (magicItem == null)
            return;
        
        animator.SetTrigger("Cast");
    }

    public void ToggleVisibilityItems()
    {
        
    }
}