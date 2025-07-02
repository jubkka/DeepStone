using System;
using UnityEngine;

public abstract class Construct : Damageable
{
    [SerializeField] protected GameObject obj;
    [SerializeField] protected float durability;
    [SerializeField] private SoundData breakSound;

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

    protected virtual void Deconstruct()
    {
        GameObject audioObj = new GameObject("TempDeathSound");
        AudioSource source = audioObj.AddComponent<AudioSource>();
        source.clip = breakSound.AudioClip;
        source.Play();
        
        Destroy(obj);
    }
}