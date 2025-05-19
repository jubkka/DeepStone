using UnityEngine;

public class LeftHandComponent : HandComponent
{
    [SerializeField] private RightHandComponent rightHand;
    
    public override void PutInHand(Item item)
    {
        base.PutInHand(item);
        
        if (rightHand.GetActiveItem.data is ICombatElement combatElement)
        {
            if (combatElement.IsTwoHanded)
            {
                rightHand.ClearHand();
            }
        }
    }
}