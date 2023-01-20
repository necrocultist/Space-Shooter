using UnityEngine;

[RequireComponent(typeof(HealthEvents))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(DealContactDamage))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyDetailsSO enemyDetails;
    private HealthEvents healthEvents;
    private Health health;
    [HideInInspector] public SpriteRenderer spriteRenderer;
    [HideInInspector] public Animator animator;

    private void Awake()
    {
        healthEvents = GetComponent<HealthEvents>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        healthEvents.OnHealthChanged += HandleOnHealthChangedEvent;
    }

    private void OnDisable()
    {
        healthEvents.OnHealthChanged -= HandleOnHealthChangedEvent;
    }
    
    private void HandleOnHealthChangedEvent(HealthEvents healthEvent, HealthChangedEventArgs healthEventArgs)
    {
        if (healthEventArgs.healthAmount <= 0)
        {
            EnemyDestroyed();
        }
    }

    private void EnemyDestroyed()
    {
        healthEvents.CallDestroyEvent(false, health.GetStartHealth());
    }

    public void InitializeEnemy(EnemyDetailsSO enemyDetails)
    {
        this.enemyDetails = enemyDetails;
        
        SetEnemyStartHealth();
        
        //TODO: Set enemy weapon, movement and animation speed
    }

    private void SetEnemyStartHealth()
    {
        health.SetStartHealth(enemyDetails.enemyHealthAmount);
    }
}
