using UnityEngine;

[CreateAssetMenu(fileName = "Test Enemy", menuName = "Enemy/Test Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private string enemyName;
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float visionRange = 1;
    [SerializeField] private float angleRange = 80f;
    public int GetHealth => health;
    public int GetDamage => damage;
    public float GetVisionRange => visionRange;
    public float GetAngleRange => angleRange;

    public GameObject GetPrefab => prefab;
}