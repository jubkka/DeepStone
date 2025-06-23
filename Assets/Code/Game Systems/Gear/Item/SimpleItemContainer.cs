using UnityEngine;

public class SimpleItemContainer : GenericContainer
{
    [SerializeField] private SimpleItemData data;

    public override GenericElementData Data => data;

    protected override void Start()
    {
        item = new (data);
        infoPanel.SetData(data);
    }
}