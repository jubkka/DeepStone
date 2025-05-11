using System;
using UnityEngine;
using UnityEngine.UI;

public class AttributeIncreaseUI : MonoBehaviour
{
    [SerializeField] private Sprite activeIncrease;
    [SerializeField] private Sprite nonActiveIncrease;
    
    private Image[] images;

    private void Start()
    {
        CharacterStatsSystems.Instance.LevelComponent.OnCountFreePointsChanged += ChangeIcon;
        images = GetComponentsInChildren<Image>();
    }

    private void ChangeIcon(int amount)
    {
        Sprite icon = amount > 0 ? activeIncrease : nonActiveIncrease; 
        
        foreach (var image in images)
            image.sprite = icon;
    }
}
