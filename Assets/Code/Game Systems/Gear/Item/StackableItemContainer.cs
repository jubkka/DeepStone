using UnityEngine;

public class StackableItemContainer : GenericContainer
{
    [SerializeField] private StackableItemData data;
    [SerializeField] protected int amount;

    public override GenericElementData Data => data;
    protected override void Start()
    {
        item = new (data, amount);
        infoPanel.SetData(item.data);
    }
}
