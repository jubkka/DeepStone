using UnityEngine;

public class ChestContainer : MonoBehaviour
{
    [SerializeField] private Item[] items;
    public Item[] Items 
    { 
        get => items;
        set => items = value;
    }
}
