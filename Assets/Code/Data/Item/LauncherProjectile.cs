using UnityEngine;
using System.Collections;


public abstract class LauncherProjectile : MonoBehaviour
{
    [Header("Generic Values")]
    [SerializeField] protected float force;
    [SerializeField] protected float delayToDestroy = 30f;
    
    [Header("Components")]
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected BoxCollider boxCollider;
    
    private Vector3 direction;
    public abstract GenericElementData Data { set; }

    public virtual void Init(Transform dir)
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        
        direction = dir.forward;
        
        transform.rotation = Quaternion.LookRotation(direction, dir.up);
        transform.rotation *= Quaternion.Euler(90f, 0f, 0f);
        Launch();
    }

    protected virtual void Launch() => rb.velocity = direction * force;

    protected abstract void OnCollisionEnter(Collision other);
    
    protected abstract void TouchObject(GameObject obj);
    
    protected virtual IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(delayToDestroy);
        Destroy(gameObject);
    }
}