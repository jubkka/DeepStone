using UnityEngine;

public class SpellCastingComponent : MonoBehaviour
{
    [SerializeField] private AttackView attackView;
    
    [Header("Magic Hand Component")]
    [SerializeField] private GameObject magicObj;
    [SerializeField] private Animator animator;
    
    private CombatSystems combatSystems;
    private AttributeComponent attributeComponent;

    public void Init(CombatSystems combat, AttributeComponent attribute)
    {
        combatSystems = combat;
        attributeComponent = attribute;

        combatSystems.MagicHand.OnActiveItemChanged += GetComponents;
        GetComponents(combatSystems.MagicHand.GetActiveItem);
    }

    private void GetComponents(Item item)
    {
        if (item.data == null)
            return;

        magicObj = combatSystems.MagicHand.GetActiveItemGameObject;
        magicObj.GetComponentInChildren<ItemAttack>()?.Init(attributeComponent, combatSystems.Effect, attackView);
        animator = magicObj.GetComponent<Animator>();
    }

    public void Cast()
    {
        if (magicObj == null)
            return;
        
        animator.SetTrigger("Cast");
    }
}