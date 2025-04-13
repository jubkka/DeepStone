using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class IndicatorView : MonoBehaviour 
{
    private TextMeshProUGUI textTMP;
    private Slider slider;
    private void Awake()
    {
        textTMP = GetComponentInChildren<TextMeshProUGUI>();
        slider = GetComponentInChildren<Slider>();
    }

    public void ChangeCurrent(int current, int max) 
    { 
        textTMP.text = current.ToString() + "/" + max.ToString();
        slider.DOValue(current, 0.25f);
    }
}