using UnityEngine;

public class GoldContainer : MonoBehaviour
{
    [SerializeField] private int amountGold; 
    public int GetAmount => amountGold;
}
