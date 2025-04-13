using UnityEngine;

public class GoldController : MonoBehaviour 
{
    public static GoldController Instance;
    private GoldModel gold;
    
    private void Awake()
    {
        Instance = this;
        gold = new GoldModel(0);
    }

    public void Give(int count) 
    {
        gold.Increase(count);

        Debug.Log($"Gold count increase: {count}");
    } 
    public void Take(int count)
    {
        gold.Decrease(count);

        Debug.Log($"Gold count decrease: {count}");
    } 
}