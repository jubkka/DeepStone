using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorComponent : MonoBehaviour, ILoad
{
    [Header("Indicator Views")]
    [SerializeField] private IndicatorView healthView;
    [SerializeField] private IndicatorView manaView;
    [SerializeField] private IndicatorView staminaView;
    
    [Header("Regeneration views")]
    [SerializeField] private RegenerationView regenerationView;

    [Header("Settings")] 
    [SerializeField] private float baseHealth;
    [SerializeField] private float baseMana;
    [Space(10)]
    [SerializeField] private float healthPerConstitution;
    [SerializeField] private float manaPerWisdom;
    [Space(10)]
    [SerializeField] private float cooldownToRegenHealth;
    [SerializeField] private float cooldownToRegenMana;
    [Space(10)]
    [SerializeField] [Range(0f, 100f)] private float regenerationPercent;
    [SerializeField] private float regenerationScale;
    
    private Health health;
    private Mana mana;
    private Stamina stamina;
    
    public Health Health => health;
    public Mana Mana => mana;
    public Stamina Stamina => stamina;

    public bool isDead;

    public float RegenerationPercent
    {
        get => regenerationPercent;
        set
        {
            regenerationPercent = Mathf.Clamp(value, 0f, 100f);
            OnRegenerationPercentChanged?.Invoke(regenerationPercent);
        }
    }

    public event Action OnHealthZero;
    public event Action<float> OnRegenerationPercentChanged;
    
    public void LoadFromOrigin(Origin origin)
    {
        float constitutionValue = origin.GetAttributesData.Constitution.Value;
        float wisdomValue = origin.GetAttributesData.Wisdom.Value;
        
        float maxValueHealth = baseHealth + (constitutionValue * healthPerConstitution);
        float maxValueMana = baseMana + (wisdomValue * manaPerWisdom);
        
        health = new Health(maxValueHealth, maxValueHealth, healthView);
        mana = new Mana(maxValueMana, maxValueMana, manaView);

        InitUI();
    }

    private void Start()
    {
        StopAllCoroutines();
        
        StartCoroutine(RestoreManaCoroutine());
        StartCoroutine(RestoreHealthCoroutine());
    }
    
    private void InitUI()
    {
        regenerationView.Init(this);
    }

    public void LoadFromSave() //TODO
    {
    }

    public void Heal(float value) => health.Increase(value);

    public void Hit(float value)
    {
        health.Decrease(value);

        if (health.Current <= 0 && !isDead)
        {
            StopAllCoroutines();
            OnHealthZero?.Invoke();
            isDead = true;
        }
    }
    
    public void Cast(float value) => mana.Decrease(value);
    public void RestoreMana(float value) => mana.Increase(value);

    private IEnumerator RestoreManaCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            float restoreMana = (1f / cooldownToRegenMana) * (1f + regenerationPercent / 100f) * (mana.Max / regenerationScale);
            
            RestoreMana(restoreMana);
        }
    }
    
    private IEnumerator RestoreHealthCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); 
            float restoreHealth = (1f / cooldownToRegenHealth) * (1f + regenerationPercent / 100f) * (health.Max / regenerationScale);
            
            Heal(restoreHealth);
        }
    }
}