using UnityEngine;

public class CombinedSpellData : ScriptableObject, ICombatElement, ISpellBehavior
{
    [SerializeField] private float damage;

    public GripType GetGripType { get; }
    
    public float GetDamage => damage;
    
    public void Cast(GameObject target)
    {
        throw new System.NotImplementedException();
    }
}