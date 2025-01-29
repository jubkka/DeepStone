using TMPro;
using UnityEngine;

public class IndicatorView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI TMP;
    public void ChangeMax(int max) => TMP.text = max.ToString() + "/" + max.ToString();
    public void ChangeCurrnet(int current, int max) => TMP.text = current.ToString() + "/" + max.ToString();
}