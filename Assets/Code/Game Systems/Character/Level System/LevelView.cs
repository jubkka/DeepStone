using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private CharacterList characterList;
    [SerializeField] private TextMeshProUGUI tmp;

    private void Start()
    {
        characterList.levelSystem.OnLevelUp += UpdateLevel;
    }

    private void UpdateLevel(int level)
    {
        tmp.text = level.ToString();
    }
}
