using UnityEngine;

public class MouseInputControl : MonoBehaviour
{
    private HandComponent hand;

    private void Start()
    {
        hand = GameSystems.Instance.GetHandComponent;
        
        InputManager.Instance.OnUseItemPressed += RightClick;
    }

    private void RightClick()
    {
        hand.UseItemInHand();
    }
}