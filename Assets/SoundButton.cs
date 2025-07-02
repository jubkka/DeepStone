using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    private Button button;

    private void Awake() 
    {
        button = GetComponent<Button>();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (button.interactable)
            SFXAudioManager.Instance.PlaySound("ButtonHover");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (button.interactable)
            SFXAudioManager.Instance.PlaySound("ButtonClick");
    }
}
