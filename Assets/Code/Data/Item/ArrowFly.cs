using System;
using Unity.Mathematics;
using UnityEngine;

public class ArrowFly : MonoBehaviour
{
    [SerializeField] private float force;
    
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private bool hasHit = false;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        
        Vector3 dir = Camera.main.transform.forward;
        rb.velocity = dir * force;

        transform.rotation = Quaternion.LookRotation(dir, Camera.main.transform.up);
    }

    private void FixedUpdate()
    {
        if (hasHit)
            return;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (hasHit)
            return;
        
        GameObject otherObject = other.gameObject;
        Damageable damageable = otherObject.GetComponentInChildren<Damageable>();

        if (damageable != null)
            damageable.GetDamage(1);

        rb.isKinematic = true;
        transform.parent = otherObject.transform;
        
        hasHit = true;
        boxCollider.enabled = false;
    }
}
