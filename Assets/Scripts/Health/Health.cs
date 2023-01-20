using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthEvents))]
[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private int startHealth;
    private int currentHealth;
    private HealthEvents healthEvents;
    private Player player;
    private Coroutine immunityCoroutine;
    private float immunityTime = 0f;
    private bool isImmuneAfterHit = false;
    private SpriteRenderer spriteRenderer = null;
    private const float spriteFlashInterval = 0.2f;
    private WaitForSeconds WaitForSecondsFlashInterval = new WaitForSeconds(spriteFlashInterval);

    [HideInInspector] public bool isDamageable = true;
    [HideInInspector] public Enemy enemy;

    private void Awake()
    {
        healthEvents = GetComponent<HealthEvents>();
    }

    private void Start()
    {
        // Trigger a health event for UI update
        CallHealthEvent(0);

        player = GetComponent<Player>();
        enemy = GetComponent<Enemy>();

        // Get player / enemy hit immunity details
        if (player != null)
        {
            if (player.playerDetails.isImmuneAfterHit)
            {
                isImmuneAfterHit = true;
                immunityTime = player.playerDetails.hitImmunityTime;
                spriteRenderer = player.spriteRenderer;
            }
        }
        else if (enemy != null)
        {
            if (enemy.enemyDetails.isImmuneAfterHit)
            {
                isImmuneAfterHit = true;
                immunityTime = enemy.enemyDetails.hitImmunityTime;
                spriteRenderer = enemy.spriteRenderer;
            }
        }

        if (enemy != null && healthBar != null && enemy.enemyDetails.isHealthBarDisplayed)
        {
            healthBar.EnableHealthBar();
        }
        else if (healthBar != null)
        {
            healthBar.DisableHealthBar();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDamageable)
        {
            currentHealth -= damageAmount;
            CallHealthEvent(damageAmount);

            PostHitImmunity();

            if (healthBar != null)
            {
                healthBar.SetHealthBarValue((float)currentHealth / (float)startHealth);
            }
        }
    }

    private void PostHitImmunity()
    {
        if (gameObject.activeSelf == false) return;

        if (isImmuneAfterHit)
        {
            if (immunityCoroutine != null)
                StopCoroutine(immunityCoroutine);

            immunityCoroutine = StartCoroutine(PostHitImmunityRoutine(immunityTime, spriteRenderer));
        }
    }

    private IEnumerator PostHitImmunityRoutine(float immunityTime, SpriteRenderer spriteRenderer)
    {
        isDamageable = false;

        for (int iterations = Mathf.RoundToInt(immunityTime / spriteFlashInterval / 2f); iterations > 0; iterations--)
        {
            var color = spriteRenderer.color;
            color = Color.red;

            yield return WaitForSecondsFlashInterval;

            color = Color.white;
            spriteRenderer.color = color;

            yield return WaitForSecondsFlashInterval;

            yield return null;
        }

        isDamageable = true;
    }

    private void CallHealthEvent(int damageAmount)
    {
        healthEvents.CallHealthChangedEvent(currentHealth / startHealth, currentHealth, damageAmount);
    }

    public void SetStartHealth(int startHealth)
    {
        this.startHealth = startHealth;
        currentHealth = startHealth;
    }

    public int GetStartHealth()
    {
        return startHealth;
    }

    public void AddHealthByPercent(int healthPercent)
    {
        int healthIncrease = Mathf.RoundToInt(startHealth * healthPercent / 100f);

        int totalHealth = currentHealth + healthIncrease;

        if (totalHealth < startHealth)
        {
            currentHealth = totalHealth;
        }
        else
        {
            currentHealth = startHealth;
        }
        
        CallHealthEvent(0);
    }
}