using UnityEngine;
using UnityEngine.AI;

public class Enemy : Damageable
{
    [Header("Player")]
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private DamageComponent damageComponent;
    [SerializeField] private LevelComponent levelComponent;
    
    [Header("Components")]
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private AudioSource audioSource;
    
    [Header("Sounds")]
    [SerializeField] private SoundData deathSound;
    [SerializeField] private SoundData damageSound;
    [SerializeField] private SoundData attackSound;
    [SerializeField] private SoundData walkSound;
    
    [Header("Script components")]
    [SerializeField] private EnemyIndicatorView indicatorView;
    [SerializeField] private Health hp;
    [SerializeField] private StateManager stateManager;
    
    [Header("Data")]
    [SerializeField] private EnemyData data;
    
    [Header("Actions")]
    [SerializeField] private EnemyHealth health;
    [SerializeField] private EnemyMemory memory;
    [SerializeField] private EnemyAttack attack;
    [SerializeField] private EnemyMove move;
    [SerializeField] private EnemyVision vision;
    [SerializeField] private EnemyRotate rotate;
    
    public SoundData DeathSound => deathSound;
    public SoundData AttackSound => attackSound;
    public SoundData WalkSound => walkSound;
    public SoundData DamageSound => damageSound;
    
    public LayerMask PlayerMask => playerMask;
    public GameObject Player => player;
    public DamageComponent DamageComponent => damageComponent;
    public Animator Animator => animator;
    public NavMeshAgent NavMeshAgent => navMeshAgent;
    public EnemyData Data => data;
    public EnemyHealth Health => health;
    public EnemyVision Vision => vision;
    public EnemyMemory Memory => memory;
    public EnemyAttack Attack => attack;
    public EnemyMove Move => move;
    public EnemyRotate Rotate => rotate;
    public Camera PlayerCamera => playerCamera;
    public GameObject EnemyObj => enemyObj;
    public Health HP
    {
        get => hp;
        set => hp = value;
    }
    public EnemyIndicatorView IndicatorView => indicatorView;

    private void Start()
    {
        InitEnemy();

        if (player == null)
            PlayerInit();
    }

    private void InitEnemy()
    {
        indicatorView.Init();
        
        hp = new Health(data.GetHealth, data.GetHealth, indicatorView);
        animator.SetFloat("SpeedAttackMultiplier", data.GetSpeedAttack);
        animator.SetFloat("SpeedMultiplier", data.GetSpeed / 2f);
        navMeshAgent.speed = data.GetSpeed * 1.5f;
    }

    public void PlayerInit()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            damageComponent = player.GetComponentInChildren<DamageComponent>();
            levelComponent = player.GetComponentInChildren<LevelComponent>();
            
            playerCamera = Camera.main;
        }
    }

    public override void GetDamage(float damage)
    {
        health.TakeDamage(damage);

        if (health.CheckDeath())
        {
            PlayDeathSound();
            levelComponent.AddExp(data.GetExpGain);
            
            Destroy(enemyObj);
        }
    }

    public void PlaySound(SoundData soundData)
    {
        audioSource.PlayOneShot(soundData.AudioClip, soundData.Volume);
    }

    private void PlayDeathSound()
    {
        GameObject audioObj = new GameObject("TempDeathSound");
        AudioSource source = audioObj.AddComponent<AudioSource>();
        source.clip = deathSound.AudioClip;
        source.Play();

        Destroy(audioObj, source.clip.length);
    }

    public void Freeze()
    {
        animator.speed = 0;
        stateManager.isPaused = true;
        navMeshAgent.isStopped = true;
    }

    public void UnFreeze()
    {
        animator.speed = 1;
        stateManager.isPaused = false;
        navMeshAgent.isStopped = false;
    }
}
