using UnityEngine;

public class EnemyTester : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            enemy.GetDamage(1);
    }
}
