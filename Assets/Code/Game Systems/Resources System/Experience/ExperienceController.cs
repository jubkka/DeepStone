using UnityEngine;

public class ExperienceController : MonoBehaviour
{
    [SerializeField] private ExperienceView view;
    private ExperienceModel model;
    
    private void Start()
    {
        LevelComponent levelComponent = CharacterStatsSystems.Instance.LevelComponent;
        model = new ExperienceModel(view);

        levelComponent.OnExpChanged += SetExp;
        levelComponent.OnCountExpToNextLevelChanged += SetCountExpToLevelUp;
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
