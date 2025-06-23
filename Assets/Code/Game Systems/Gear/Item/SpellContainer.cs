using UnityEngine;

public class SpellContainer : GenericContainer
{
    [SerializeField] private SpellData data;
    public override GenericElementData Data => data;

    protected override void Start()
    {
        item = new Item(data);
    }
}