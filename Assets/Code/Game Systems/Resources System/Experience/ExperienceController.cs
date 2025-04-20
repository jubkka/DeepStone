using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    [SerializeField] private ExperienceView view;
    [SerializeField] private CharacterList characterList;
    private ExperienceModel model;
    
    private void Start()
    {
        model = new ExperienceModel(view);

        characterList.levelSystem.OnExpChanged += SetExp;
        characterList.levelSystem.OnCountExpToNextLevelChanged += SetCountExpToLevelUp;
    }

    private void SetExp(int value)
    {
        model.CurrentExp = value;
    }

    private void SetCountExpToLevelUp(int value)
    {
        model.CountExpToNextLevel = value;
    }
}
