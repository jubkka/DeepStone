public interface ICombatElement  
{
    public GripType GetGripType { get; }
    public float GetDamage { get; }
    public bool IsTwoHanded => GetGripType == GripType.TwoHanded;
}