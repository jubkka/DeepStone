using UnityEngine;

public class DoorConstruct : Construct
{
    [SerializeField] private GameObject door;
    
    protected override void Deconstruct()
    {
        Destroy(door);
    }
}