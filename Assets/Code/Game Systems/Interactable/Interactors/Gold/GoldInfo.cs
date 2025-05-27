using UnityEngine;

public class GoldInfo : MonoBehaviour
{
    [SerializeField] private GoldComponent goldComponent;
    [SerializeField] private int goldAmount = 0;
    
    private void Start()
    {
        goldComponent.OnGoldChanged += ChangeGold;
    }

    private void ChangeGold(int amount) => goldAmount = amount;
}