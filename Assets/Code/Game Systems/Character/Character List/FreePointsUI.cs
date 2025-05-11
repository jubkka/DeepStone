using TMPro;
using UnityEngine;

public class FreePointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    private void Start()
    {
        CharacterStatsSystems.Instance.LevelComponent.OnCountFreePointsChanged += UpdateFreePoints;
    }

    private void UpdateFreePoints(int value)
    {
        tmp.text = value.ToString();
    }
}
