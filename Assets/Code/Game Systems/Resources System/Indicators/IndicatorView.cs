using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IndicatorView : MonoBehaviour 
{
    protected TextMeshProUGUI textTMP;
    protected Slider slider;
    
    protected virtual void Awake()
    {
        textTMP = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponentInChildren<Slider>();
    }

    public void ChangeValue(int current, int max) 
    { 
        textTMP.text = current + "/" + max;
        slider.DOValue(current, 0.25f);
    }

    public void ChangeSliderMax(int max)
    {
        slider.maxValue = max;
    }

    public void Init(int current, int max)
    {
        ChangeValue(current, max);
        ChangeSliderMax(max);
    }
}