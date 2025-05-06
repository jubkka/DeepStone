using System;
using UnityEngine;

[Serializable]
public class LevelSystem
{
    [SerializeField] private int level;
    [SerializeField] private int exp;
    [SerializeField] private int countFreePoints;
    
    [SerializeField] private int countPointsPerLevel;
    [SerializeField] private int countExpToNextLevel;

    public int Level
    {
        get => level;
        private set
        {
            level = value;
            OnLevelUp?.Invoke(value);
            OnCountExpToNextLevelChanged?.Invoke(DefaultXPFormula());
        }
    }

    public int Exp
    {
        get => exp;
        private set
        {
            exp = value;
            OnExpChanged?.Invoke(value);
        }
    }

    public int CountFreePoints
    {
        get => countFreePoints;
        set
        {
            countFreePoints = value;
            OnCountFreePointsChanged?.Invoke(value);
        }
    }

    public int CountPointsPerLevel => countPointsPerLevel;

    public int CountExpToNextLevel => countExpToNextLevel;

    public event Action<int> OnLevelUp;
    public event Action<int> OnExpChanged;
    public event Action<int> OnCountExpToNextLevelChanged;
    public event Action<int> OnCountFreePointsChanged;
    
    public LevelSystem(int level, int exp, int countPointsPerLevel)
    {
        this.level = level;
        this.exp = exp;
        this.countPointsPerLevel = countPointsPerLevel;
    }

    public void AddExp(int amount)
    {
        Exp += amount;

        while (exp >= DefaultXPFormula())
        {
            Exp -= DefaultXPFormula();
            Level++;
            CountFreePoints += countPointsPerLevel;
        }
        
        countExpToNextLevel = DefaultXPFormula() - exp;
    }

    private int DefaultXPFormula()
    {
        return 100 + (level - 1) * 50;
    }
}