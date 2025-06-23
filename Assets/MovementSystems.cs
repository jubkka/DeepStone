using UnityEngine;

public class MovementSystems : Systems
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotate playerRotate;
    
    private static MovementSystems instance;
    public static MovementSystems Instance => instance;

    public override void Init(BootstrapCharacter bootstrapCharacter)
    {
        instance = this;

        playerMovement.Initialize(bootstrapCharacter.CharacterStatsSystems.Attribute, bootstrapCharacter.ResourceSystems.Weight);
        //playerRotate.Initialize();
    }
}