using System.Collections;
using UnityEngine;

public class LauncherArrow : LauncherProjectile
{
    private WeaponData data;

    public override GenericElementData Data
    {
        set => data = (WeaponData)value;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        GameObject otherObject = other.gameObject;

        FreezeArrow();
        SetParent(otherObject);
        TouchObject(otherObject);
        
        StartCoroutine(DestroyAfterDelay());
    }

    protected override void Launch()
    {
        base.Launch();
        
        StartCoroutine(OnGravity());
    }

    private IEnumerator OnGravity()
    {
        rb.useGravity = false;
        yield return new WaitForSeconds(0.25f);
        
        rb.useGravity = true;
    }

    private void FreezeArrow()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;
        boxCollider.enabled = false;
    }

    private void SetParent(GameObject obj)
    {
        GameObject containerArrow = new GameObject();
        containerArrow.transform.SetParent(obj.transform);
        
        transform.SetParent(containerArrow.transform);
    }

    protected override void TouchObject(GameObject obj)
    {
        Damageable damageable = obj.GetComponentInChildren<Damageable>();
        
        if (damageable != null)
            damageable.GetDamage(data.Damage);
    }
}
