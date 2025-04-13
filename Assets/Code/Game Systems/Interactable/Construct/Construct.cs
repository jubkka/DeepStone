using System;
using UnityEngine;

public abstract class Construct : MonoBehaviour
{
    [SerializeField] protected int durability;

    protected GameObject parent;

    protected virtual void Start()
    {
        parent = transform.parent.gameObject;
    }

    public void GetDamage(int damage)
    {
        durability = Math.Max(0, durability - damage);

        if (durability <= 0)
            Deconstruct();
    }

    protected virtual void Deconstruct()
    {
        Destroy(parent);
    }
}