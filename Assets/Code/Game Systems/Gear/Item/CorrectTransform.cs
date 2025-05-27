using System;
using UnityEngine;

public class CorrectTransform : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Vector3 angle;
    [SerializeField] private float positionY;

    [SerializeField] private Transform model;

    public void Setup()
    {
        model.eulerAngles = angle;
        transform.position = new Vector3(model.position.x, positionY, model.position.z);
    }
}