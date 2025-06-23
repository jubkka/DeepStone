using System.Collections.Generic;
using UnityEngine;

public abstract class SpellBehavior : ScriptableObject, ISpellBehavior
{
    public abstract void Cast(GameObject target);
    public abstract void CreateDescription();
}