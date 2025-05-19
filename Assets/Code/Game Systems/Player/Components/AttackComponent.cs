using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private RightHandComponent rightHand;
    
    private GameObject activeItemGameObject;
    private Animator animator;
    
    private void Start()
    {
        rightHand = CombatSystems.Instance.GetRightHand;
        rightHand.OnActiveItemChanged += GetComponents;

        GetComponents(rightHand.GetActiveItem);
    }

    private void GetComponents(Item item)
    {
        if (item.data == null)
            return;
        
        activeItemGameObject = rightHand.GetActiveItemGameObject;
        animator = activeItemGameObject.GetComponent<Animator>();
    }

    public void Attack()
    {
        if (activeItemGameObject == null)
            return;
        
        animator.SetTrigger("Attack");
    }
}