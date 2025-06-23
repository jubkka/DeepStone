using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] private CameraShaker cameraShaker;
    
    private DefenceComponent defenceComponent;
    private IndicatorComponent indicatorComponent;

    public void Init(DefenceComponent defence, IndicatorComponent indicator) //TODO Мейби сделать обычный класс не монобех ?
    {
        defenceComponent = defence;
        indicatorComponent = indicator;
    }

    public void TakeDamageByEnemy(float physicalDamage = 0f, float magicalDamage = 0f)
    {
        float physicalValue = physicalDamage * (100f / (100f + defenceComponent.PhysicalDef));
        float magicalValue = magicalDamage * (100f / (100f + defenceComponent.MagicalDef));
        
        float totalDamage = physicalValue + magicalValue;

        Damage(totalDamage);
    }

    public void TakeDamageByEffect(float damage)
    {
        Damage(damage);
    }

    private void Damage(float damage)
    {
        indicatorComponent.Hit(damage);
        cameraShaker.ShakeDamage();
        
        SFXAudioManager.Instance.PlaySound("GetDamage");
    }
}
