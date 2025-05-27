using UnityEngine;

public class WeightInfo : MonoBehaviour
{
    [SerializeField] private WeightComponent weightComponent;
    [SerializeField] private int weightCurrent;
    [SerializeField] private int weightMax;

    private void Start()
    {
        weightComponent.OnWeightCurrentChanged += ChangeCurrent;
        weightComponent.OnWeightMaxChanged += ChangeMax;    
    }
    
    private void ChangeCurrent(int newValue) => weightCurrent = newValue;
    private void ChangeMax(int newValue) => weightMax = newValue;
}