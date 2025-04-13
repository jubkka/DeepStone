public class ConstructDamageable : Damageable
{
    private Construct construct;

    private void Awake()
    {
        construct = GetComponent<Construct>();
    }

    public override void GetDamage(int damage)
    {
        construct.GetDamage(damage);
    }
}