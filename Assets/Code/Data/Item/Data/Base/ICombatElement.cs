public interface ICombatElement  
{
    public GripType GetGripType { get; }
    public float Damage { get; }
    public bool IsTwoHanded => GetGripType == GripType.TwoHanded;
}