using UnityEngine;
using UnityEngine.UI;

public class ConstructDamageable : Damageable
{
    private DoorConstruct doorConstruct;

    [SerializeField] private Slider health;

    private void Awake()
    {
        doorConstruct = GetComponent<DoorConstruct>();
        health.maxValue = 3;
        health.value = health.maxValue;
    }

    public override void GetDamage(int damage)
    {
        doorConstruct.GetDamage(damage);
        health.value -= damage;
    }
}