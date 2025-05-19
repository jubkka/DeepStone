using UnityEngine;

public class SimpleItemContainer : GenericContainer
{
    [SerializeField] private SimpleItemData data;

    protected override void Start()
    {
        item = new (data);
    }
}