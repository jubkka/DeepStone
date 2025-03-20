using UnityEngine;

public class GoldController : MonoBehaviour 
{
    private GoldModel gold;
    static public GoldController Instance;
    private void Awake()
    {
        gold = new GoldModel(0);
        Singleton();
    }

    private void Singleton() 
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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