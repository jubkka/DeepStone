using UnityEngine;

public class WeaponContainer : GenericContainer
{
    [SerializeField] private WeaponData data;
    [SerializeField] private Animator animator;
    public override GenericElementData Data => data;
    
    protected override void Start()
    {
        item = new(data);
        infoPanel.SetData(data);
        animator.SetFloat("speedAttack", data.SpeedAttack);
    }
}