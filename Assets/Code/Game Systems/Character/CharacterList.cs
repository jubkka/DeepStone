using System;
using UnityEngine;

public class CharacterList : MonoBehaviour
{
    [Header("Level System")] public LevelSystem levelSystem;

    [Space(10)]
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private int currentExp = 0;
    [SerializeField] private int countPointsPerLevel = 3;

    [Header("Attribute System")]
    public AttributeSystem attributeSystem;

    [Space(10)] 
    [SerializeField] private int str = 0;
    [SerializeField] private int con = 0;
    [SerializeField] private int dex = 0;
    [SerializeField] private int per = 0;
    [SerializeField] private int intel = 0;
    [SerializeField] private int wis = 0;
    
    private void Awake() => Init();
    
    private void Init()
    {
        attributeSystem = new AttributeSystem(str, con, dex, per, intel, wis);
        levelSystem = new LevelSystem(currentLevel, currentExp, countPointsPerLevel);
    }

    public void AttributeIncrease(AttributeType attributeType)
    {
        if (levelSystem.CountFreePoints == 0)
            return;
        
        Attribute attribute = attributeSystem.GetAttribute(attributeType);
        attribute.Value += 1;
        
        levelSystem.CountFreePoints -= 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            levelSystem.AddExp(100);
    }
}