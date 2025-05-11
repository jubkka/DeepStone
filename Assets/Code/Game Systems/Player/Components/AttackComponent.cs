using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private HandComponent handComponent;
    
    private GameObject activeItemGameObject;
    private Animator animator;
    
    private void Start()
    {
        handComponent = CombatSystems.Instance.GetHandComponent;
        handComponent.OnActiveItemChanged += GetComponents;

        GetComponents(handComponent.GetActiveItem);
    }

    private void GetComponents(Item item)
    {
        if (item.data == null)
            return;
        
        activeItemGameObject = handComponent.GetActiveItemGameObject;
        animator = activeItemGameObject.GetComponent<Animator>();
    }

    public void Attack()
    {
        if (activeItemGameObject == null)
            return;
        
        animator.SetTrigger("Attack");
    }
}