using System;
using UnityEngine;

public class CorrectTransform : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Vector3 angle;
    [SerializeField] private float positionY;

    private Transform parent;

    public void Setup()
    {
        parent = transform.parent;
        parent.eulerAngles = angle;
        parent.position = new Vector3(parent.position.x, positionY, parent.position.z);
    }
}