using UnityEngine;

public class LauncherSpell : LauncherProjectile
{
    private SpellData data;
    
    public override void Init(Transform dir)
    {
        base.Init(dir);
        
        StartCoroutine(DestroyAfterDelay());
        Launch();
    }

    public override void SetData(GenericContainer container)
    {
        data = (SpellData)container.GetItem.data;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        GameObject obj = other.gameObject;

        if (obj.tag == "Player")
            return;
        
        TouchObject(obj);
        Destroy(gameObject);
    }

    protected override void TouchObject(GameObject obj)
    {
        data.Cast(obj);
    }
}