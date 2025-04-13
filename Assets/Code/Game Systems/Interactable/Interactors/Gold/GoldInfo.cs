using UnityEngine;

public class GoldInfo : MonoBehaviour {
    [SerializeField] private int gold;
    private void Awake()
    {
        GoldModel.OnGoldChanged += GoldCountChange;
    }
    private void GoldCountChange(int count) 
    {
        gold = count;
    }
}