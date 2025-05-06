using TMPro;
using UnityEngine;

public class FreePointsUI : MonoBehaviour
{
    [SerializeField] private CharacterList characterList;
    [SerializeField] private TextMeshProUGUI tmp;

    private void Start()
    {
        characterList.levelSystem.OnCountFreePointsChanged += UpdateFreePoints;
    }

    private void UpdateFreePoints(int value)
    {
        tmp.text = value.ToString();
    }
}
