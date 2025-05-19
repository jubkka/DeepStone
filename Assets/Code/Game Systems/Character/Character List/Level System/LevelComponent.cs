using System;
using UnityEngine;

public class LevelComponent : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private int exp = 0;
    [SerializeField] private int countFreePoints = 0;
    
    [SerializeField] private int countPointsPerLevel;
    [SerializeField] private int countExpToNextLevel;

    public int Level
    {
        get => level;
        private set
        {
            level = value;
            OnLevelUp?.Invoke(value);
            OnCountExpToNextLevelChanged?.Invoke(DefaultXpFormula());
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
    
    private void Update() //remove
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            AddExp(100);
    }

    public void AddExp(int amount)
    {
        Exp += amount;

        while (exp >= DefaultXpFormula())
        {
            Exp -= DefaultXpFormula();
            Level++;
            CountFreePoints += countPointsPerLevel;
        }
        
        countExpToNextLevel = DefaultXpFormula() - exp;
    }

    private int DefaultXpFormula()
    {
        return 100 + (level - 1) * 50;
    }
}