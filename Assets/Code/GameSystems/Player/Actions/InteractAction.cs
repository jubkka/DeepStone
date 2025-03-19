using UnityEngine;

public class InteractAction : InputAction
{
    [SerializeField] private DoorInteractor interactWithDoor;
    public override void Execute()
    {
        interactWithDoor.Interact();
    }
}