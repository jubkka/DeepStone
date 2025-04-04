using System;
using UnityEngine;

public class CorrectTransform : MonoBehaviour
{
    [SerializeField] private Vector3 angle;
    [SerializeField] private float positionY;

    private Transform parent;
    private Animator animator;
    
    private void Start()
    {
        parent = transform.parent;
        animator = parent.GetComponent<Animator>();
        
        Setup();
    }

    public void Setup()
    {
        parent.eulerAngles = angle;
        parent.position = new Vector3(parent.position.x, positionY, parent.position.z);
    }
}