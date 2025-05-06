using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Table", menuName = "Table/New Item Table")]
public class ItemTable : ScriptableObject
{
    public List<LootItem> items;
}