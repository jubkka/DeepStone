using TMPro;
using UnityEngine;

public class FreePointsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    private void Start()
    {
        CharacterStatsSystems.Instance.Level.OnCountFreePointsChanged += UpdateFreePoints;
    }

    private void UpdateFreePoints(int value)
    {
        tmp.text = value.ToString();
    }
}
