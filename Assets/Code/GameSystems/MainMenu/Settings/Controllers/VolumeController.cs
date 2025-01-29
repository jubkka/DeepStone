using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider effectsSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TextMeshProUGUI effectsTMP;
    [SerializeField] private TextMeshProUGUI musicTMP;

    public void ChangeEffects() 
    {
        Settings.Effects = (int)effectsSlider.value;

        effectsTMP.text = effectsSlider.value.ToString();
    }
    public void ChangeMusic() 
    {
        Settings.Music = (int)musicSlider.value;

        musicTMP.text = musicSlider.value.ToString();
    }
}
