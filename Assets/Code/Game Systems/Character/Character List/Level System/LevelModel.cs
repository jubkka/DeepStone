using System;
using UnityEngine;

[Serializable]
public class LevelModel
{
    [SerializeField] private int level = 1;
    [SerializeField] private int exp = 0;
    [SerializeField] private int freePoints = 0;
    
    [SerializeField] private int pointsPerLevel;
    [SerializeField] private int expToNextLevel;

    public int Level
    {
        get => level;
        private set
        {
            level = value;
            ExpToNextLevel = DefaultXpFormula() - exp;
            
            OnLevelUp?.Invoke(value);
        }
    }

    public int Exp
    {
        get => exp;
        private set
        {
            exp = value;
            OnExpChanged?.Invoke(exp);
        }
    }

    public int FreePoints
    {
        get => freePoints;
        set
        {
            freePoints = value;
            OnFreePointsChanged?.Invoke(value);
        }
    }

    public int PointsPerLevel
    {
        get => pointsPerLevel;
        set
        {
            pointsPerLevel = value;
            OnPointsPerLevelChanged?.Invoke(value);
        }
    }

    public int ExpToNextLevel 
    {
        get => expToNextLevel;
        set
        {
            expToNextLevel = value;
            OnExpToNextLevelChanged?.Invoke(value);
        }
    }

    public event Action<int> OnLevelUp;
    public event Action<int> OnExpChanged;
    public event Action<int> OnExpGained;
    public event Action<int> OnExpToNextLevelChanged;
    public event Action<int> OnPointsPerLevelChanged;
    public event Action<int> OnFreePointsChanged;
    
    public LevelModel()
    {
        level = 1;
        exp = 0;
        freePoints = 0;
        
        pointsPerLevel = 3; 
        expToNextLevel = 100; 
    }

    public LevelModel( int a/*Save*/)
    {
        // level = Save.GetLevel; //TODO
    }

    public void LoadFromOrigin(Origin origin)
    {
        level = 1;
        exp = 0;
        freePoints = 0;
        
        pointsPerLevel = 3; //Temp
        expToNextLevel = 100; //Todo
        
        //countPointsPerLevel = origin.GetCountPointsPerLevel;
        //countExpToNextLevel = origin.countExpToNextLevel;
    }

    public void AddExp(int amount)
    {
        Exp += amount;

        while (exp >= DefaultXpFormula())
        {
            Exp -= DefaultXpFormula();
            LevelUp();
        }
        
        OnExpGained?.Invoke(amount);
    }

    private void LevelUp()
    {
        Level++;
        FreePoints += PointsPerLevel;
        SFXAudioManager.Instance.PlaySound("LevelUP");
    }

    private int DefaultXpFormula()
    {
        return 100 + (level - 1) * 50;
    }
}