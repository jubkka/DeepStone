using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelComponent : MonoBehaviour, ILoad
{
    [Header("UI Elements")]
    [SerializeField] private FreePointsUI freePointsUI;
    [SerializeField] private LevelView levelView;
    [SerializeField] private ExperienceView experienceView;
    [SerializeField] private LevelUpView levelUpView;
    
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

    public void Init(AttributeComponent attributeComponent)
    {
        model = new LevelModel();
        attributeComponent.OnAttributeIncreased += SpendFreePoints;
        
        InitUI();
    }

    public void LoadFromOrigin(Origin origin)
    {
        model.LoadFromOrigin(origin);
    }

    private void InitUI()
    {
        freePointsUI.Init(this);
        levelView.Init(this);
        experienceView.Init(this);
        levelUpView.Init(this);
    }
    
    public void LoadFromSave() //TODO
    {
        
    }

    public void AddExp(int exp)
    {
        model.AddExp(exp);
    }
    
    public void SpendFreePoints(int amount) => model.FreePoints -= amount;
}