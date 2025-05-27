using TMPro;
using UnityEngine;

public class WeightView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI weightView;
    
    public void UpdateText(int current)
    {
        weightView.text = current.ToString();
    }
}