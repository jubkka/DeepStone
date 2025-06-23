using UnityEngine;

public class CorrectTransform : MonoBehaviour
{
    [Header("Transform for Spawning")]
    [SerializeField] private Vector3 angleSpawning;
    [SerializeField] private float positionYSpawning;
    
    [Header("Transform for Hand")]
    [SerializeField] private Vector3 angleHand;
    [SerializeField] private Vector3 positionHand;
    
    [SerializeField] private Transform model;

    public void SetupSpawning()
    {
        transform.eulerAngles = angleSpawning;
        transform.position = new Vector3(model.position.x, positionYSpawning, model.position.z);
    }
    
    public void SetupHand()
    {
        transform.localRotation = Quaternion.Euler(angleHand);
        transform.localPosition = positionHand;
    }
}