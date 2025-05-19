using UnityEngine;

public abstract class SpellBehaviorSO : ScriptableObject, ISpellBehavior
{
    public abstract void Cast(GameObject target);
}