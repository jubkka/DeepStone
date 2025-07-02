using UnityEngine;

public class ArmorContainer : GenericContainer
{
    [SerializeField] private ArmorData data;
    
    public override GenericElementData Data => data;
    protected override void Start()
    {
        item = new (data, 1);
        infoPanel.SetData(item.data);
    }
}
