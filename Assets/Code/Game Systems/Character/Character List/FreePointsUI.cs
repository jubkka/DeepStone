using TMPro;
using UnityEngine;

public class FreePointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    public void Init(LevelComponent levelComponent)
    {
        Subscribe(levelComponent);
        UpdateFreePoints(levelComponent.FreePoints);
    }

    private void Subscribe(LevelComponent levelComponent) => levelComponent.OnFreePointsChanged += UpdateFreePoints;
    
    private void UpdateFreePoints(int value)
    {
        tmp.text = value.ToString();
    }
}
