using System.Collections.Generic;
using UnityEngine;

public class ChestContainer : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    public List<Item> Items 
    { 
        get => items;
        set => items = value;
    }
}
