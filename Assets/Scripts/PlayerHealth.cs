using System;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    EnemyAI enemyAI;

    [NonSerialized] int damage;

    public float health;
    public float maxHealth;
    public Image healthBar;
    public GameManager gameManager;
    public GameObject deathParticle;
    public bool playerDead = false;

    public CameraFollow cameraShake;

    public float healAmount = 20f; // Amount to heal when colliding with healing objects

    public Image damageOverlay; // Assign this in the Inspector
    public float overlayFadeSpeed = 2f; // How quickly the overlay fades out
    private float overlayAlpha = 0f; // Current alpha value of the overlay

    void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        // Gradually fade out the red overlay
        if (overlayAlpha > 0)
        {
            overlayAlpha -= Time.deltaTime * overlayFadeSpeed;
            overlayAlpha = Mathf.Clamp(overlayAlpha, 0, 1);
            damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, overlayAlpha);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyAI = collision.gameObject.GetComponent<EnemyAI>();
            TakeDamage();
        }
        
    }

    void TakeDamage()
    {
        if (!playerDead)
        {
            health -= enemyAI.config.damage;
            Debug.Log("Player Health: " + health + ", Enemy damage: " + enemyAI.config.damage);
            cameraShake.TriggerShake(0.3f, 0.8f);

            // Update health bar
            healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);
            if (health <= 0)
            {

                Instantiate(deathParticle, transform.position, Quaternion.identity);
                playerDead = true;
                gameManager.KillPlayer();
            }

            // Trigger the red overlay effect
            TriggerDamageOverlay();
        }
    }
        
    void TriggerDamageOverlay()
    {
        overlayAlpha = 1f; // Set alpha to fully visible
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, overlayAlpha);
    }

   public void Heal(float amount)
    {
        health += amount;

        // Ensure health doesn't exceed maxHealth
        health = Mathf.Clamp(health, 0, maxHealth);

        Debug.Log("Player healed! Current Health: " + health);

        // Update health bar
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);
    }
}

