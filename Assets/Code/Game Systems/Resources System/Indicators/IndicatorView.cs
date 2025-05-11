using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IndicatorView : MonoBehaviour 
{
    [SerializeField] protected TextMeshProUGUI textTMP;
    [SerializeField] protected Slider slider;

    public void ChangeValue(int current, int max) 
    { 
        textTMP.text = current + "/" + max;
        slider.DOValue(current, 0.25f);
    }

    private void ChangeSliderMax(int max)
    {
        slider.maxValue = max;
    }

    public void Init(int current, int max)
    {
        ChangeValue(current, max);
        ChangeSliderMax(max);
    }
}