using UnityEngine;

public class WeaponContainer : GenericContainer
{
    [SerializeField] private WeaponData data;
    
    protected override void Start()
    {
        item = new(data);
        infoPanel.SetData(data);
    }
}