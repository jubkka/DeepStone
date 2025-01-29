using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlsContoller : MonoBehaviour
{
    [SerializeField] private Slider sensivitySlider;
    [SerializeField] private TextMeshProUGUI sensivityTMP;

    public void ChangeMouseSensivity() 
    { 
        sensivityTMP.text = sensivitySlider.value + "%";
        
        Settings.MouseSensivity = (int)sensivitySlider.value;
    }
}
