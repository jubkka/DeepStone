using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    private void Start()
    {
        CharacterStatsSystems.Instance.LevelComponent.OnLevelUp += UpdateLevel;
    }

    private void UpdateLevel(int level)
    {
        tmp.text = level.ToString();
    }
}
