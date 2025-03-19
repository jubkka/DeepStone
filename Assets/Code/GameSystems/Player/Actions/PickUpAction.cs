using UnityEngine;

public class PickUpAction : InputAction
{
    [SerializeField] private PickUp itemPicker;

    public override void Execute()
    {
        itemPicker.TryPickUp();
    }
}