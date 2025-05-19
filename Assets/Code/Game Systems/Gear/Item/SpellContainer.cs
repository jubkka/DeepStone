using UnityEngine;

public class SpellContainer : GenericContainer
{
    [SerializeField] private SpellData data;
    protected override void Start()
    {
        item = new Item(data);
    }
}