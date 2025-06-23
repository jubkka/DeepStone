using UnityEngine;

public class LauncherSpell : LauncherProjectile
{
    private SpellData data;

    public override GenericElementData Data
    {
        set => data = (SpellData)value;
    }

    public override void Init(Transform dir)
    {
        base.Init(dir);
        
        StartCoroutine(DestroyAfterDelay());
        Launch();
    }

    protected override void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;

        if (obj.CompareTag("Player"))
            return;
        
        TouchObject(obj);
        Destroy(gameObject);
    }

    protected override void TouchObject(GameObject obj)
    {
        data.Cast(obj);
    }
}