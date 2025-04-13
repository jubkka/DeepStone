using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    private HandComponent handComponent;
    
    private GameObject activeItemGameObject;
    private Animator animator;
    
    private void Start()
    {
        handComponent = GameSystems.Instance.GetHandComponent;
        handComponent.OnActiveItemChanged += GetComponents;
    }

    private void GetComponents(Item item)
    {
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