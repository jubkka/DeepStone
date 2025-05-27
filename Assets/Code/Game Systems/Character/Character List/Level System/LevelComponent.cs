using System;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private FreePointsUI freePointsUI;
    [SerializeField] private LevelView levelView;
    [SerializeField] private ExperienceView experienceView;
    
    [Header("Level")]
    [SerializeField] private LevelModel model;
    
    public int Exp => model.Exp;
    public int ExpToNextLevel => model.ExpToNextLevel;
    public int Level => model.Level;
    public int FreePoints => model.FreePoints;
    public int PointsPerLevel => model.PointsPerLevel;

    public event Action<int> OnLevelUp
    {
        add => model.OnLevelUp += value;
        remove => model.OnLevelUp -= value;
    }
    
    public event Action<int> OnExpChanged
    {
        add => model.OnExpChanged += value;
        remove => model.OnExpChanged -= value;
    }

    public event Action<int> OnExpGained
    {
        add => model.OnExpGained += value;
        remove => model.OnExpGained -= value;
    }

    public event Action<int> OnExpToNextLevelChanged
    {
        add => model.OnExpToNextLevelChanged += value;
        remove => model.OnExpToNextLevelChanged -= value;
    }
    
    public event Action<int> OnFreePointsChanged
    {
        add => model.OnFreePointsChanged += value;
        remove => model.OnFreePointsChanged -= value;
    }

    public void InitFromOrigin(Origin origin, AttributeComponent attributeComponent)
    {
        model = new LevelModel(origin);
        attributeComponent.OnAttributeIncreased += SpendFreePoints;

        InitUI();
    }

    private void InitUI()
    {
        freePointsUI.Init(this);
        levelView.Init(this);
        experienceView.Init(this);
    }
    
    public void InitFromSave() //TODO
    {
        
    }

    public void AddExp(int exp)
    {
        model.AddExp(exp);
    }
    
    public void SpendFreePoints(int amount) => model.FreePoints -= amount;
}