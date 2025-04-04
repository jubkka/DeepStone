using System;
using UnityEngine;

public class DoorConstruct : Construct
{
    [SerializeField] private int durability;
    [SerializeField] private int hackDifficulty;

    private GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    public void GetDamage(int damage)
    {
        durability = Math.Max(0, durability - damage);
        Debug.Log(durability);

        if (durability <= 0)
            Deconstruct();
    }

    public void Deconstruct()
    {
        Destroy(parent);
    }
}