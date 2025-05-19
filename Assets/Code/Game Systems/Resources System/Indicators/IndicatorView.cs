using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IndicatorView : MonoBehaviour 
{
    [SerializeField] protected TextMeshProUGUI textTMP;
    [SerializeField] protected Slider slider;

    public void ChangeValue(float current, float max) 
    { 
        int currentInt = Mathf.FloorToInt(current);
        int maxInt = Mathf.FloorToInt(max);
        
        textTMP.text = currentInt + "/" + maxInt;
        slider.DOValue(current, 0.25f);
    }

    private void ChangeSliderMax(float max)
    {
        slider.maxValue = max;
    }

    public void Init(float current, float max)
    {
        ChangeValue(current, max);
        ChangeSliderMax(max);
    }
}