using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    public void Init(LevelComponent levelComponent) => Subscribe(levelComponent);

    private void Subscribe(LevelComponent levelComponent) => levelComponent.OnLevelUp += UpdateLevel;

    private void UpdateLevel(int level)
    {
        tmp.text = level.ToString();
    }
}
