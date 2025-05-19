using UnityEngine;

public class StackableItemContainer : GenericContainer
{
    [SerializeField] private StackableItemData data;
    [SerializeField] protected int amount;

    protected override void Start()
    {
        item = new (data, amount);
    }
}
