using System;
using UnityEngine;

public abstract class Construct : Damageable
{
    [SerializeField] protected float durability;

    protected GameObject parent;

    protected virtual void Start()
    {
        parent = transform.parent.gameObject;
    }

    public override void GetDamage(float damage)
    {
        durability = Math.Max(0, durability - damage);

        if (durability <= 0)
            Deconstruct();
    }

    protected abstract void Deconstruct();
}