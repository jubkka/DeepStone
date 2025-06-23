using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private AttackView attackView;
    
    private RightHandComponent rightHand;
    private AttributeComponent attributeComponent;
    private EffectComponent effectComponent;
    
    private GameObject activeItemGameObject;
    private Animator animator;
    
    public void Init(RightHandComponent hand, AttributeComponent attribute, EffectComponent effect)
    {
        rightHand = hand;
        attributeComponent = attribute;
        effectComponent = effect;
        
        rightHand.OnActiveItemChanged += GetComponents;
        GetComponents(rightHand.GetActiveItem);
    }

    private void GetComponents(Item item)
    {
        if (item.data == null)
            return;
        
        if (item.data is not WeaponData)
        {
            attackView.UpdateText(0);
            return;
        }

        activeItemGameObject = rightHand.GetActiveItemGameObject;
        activeItemGameObject.GetComponentInChildren<ItemAttack>()?.Init(attributeComponent, effectComponent, attackView);
        animator = activeItemGameObject.GetComponentInChildren<Animator>();
        
        if (animator == null)
            Debug.LogWarning("Animator is Null");
    }

    public void Attack()
    {
        if (activeItemGameObject == null)
            return;
        
        animator.SetTrigger("Attack");
    }
}