using UnityEngine;
using UnityEngine.UI;

public class AttributeIncreaseUI : MonoBehaviour
{
    [SerializeField] private Sprite activeIncrease;
    [SerializeField] private Sprite nonActiveIncrease;
    
    private Image[] images;

    public void Init(LevelComponent levelComponent)
    {
        images = GetComponentsInChildren<Image>();
        levelComponent.OnFreePointsChanged += ChangeIcon;
        
        ChangeIcon(levelComponent.FreePoints);
    }

    private void ChangeIcon(int amount)
    {
        Sprite icon = amount > 0 ? activeIncrease : nonActiveIncrease; 
        
        foreach (var image in images)
            image.sprite = icon;
    }
}
