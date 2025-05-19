using UnityEngine;

public class RangeAttack : ItemAttack
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float distanceToLaunch = 1.5f; 
    
    protected override void DealDamage()
    {
        GameObject newProjectile = Instantiate(projectile, cam.transform.position, Quaternion.identity);
        LauncherProjectile launcherProjectile = newProjectile.GetComponentInChildren<LauncherProjectile>();
        
        launcherProjectile?.SetData(container);
        launcherProjectile?.Init(cam.transform);
    }
}