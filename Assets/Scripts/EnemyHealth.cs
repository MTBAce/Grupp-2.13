using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem damageParticles;

    public EnemyConfig config;
    public GameManager gameManager;
    public float playerDamageMultiplier = 1f;

    [Header("Drop Settings")]
    public GameObject[] supplies; // Lista över möjliga power-ups
    [Range(0f, 1f)] public float dropChance = 0.5f; // Sannolikheten att en power-up spawnar (0-1)

    private float health;
    public int pointsOnDeath; // Poäng som ges när fienden dör

    private PlayerWeaponHandler playerWeaponHandler;

    private void Start()
    {
        pointsOnDeath = config.scoreValue;
        gameManager = FindFirstObjectByType<GameManager>();
        playerWeaponHandler = FindFirstObjectByType<PlayerWeaponHandler>();
        health = config.health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>())
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage()
    {
        // Use the static damage multiplier from DamageModifier
        float damage = playerWeaponHandler.currentWeapon.weaponData.damage * DamageModifier.damageMultiplier;
        health -= damage;
        Debug.Log("Enemy took damage, health: " + health);
        DamageParticles();

        if (health <= 0)
        {
            Die();
            // Find the Score component in the scene
            Score score = FindFirstObjectByType<Score>();

            if (score != null)
            {
                // Add points to the player
                score.AddPoints(pointsOnDeath);
            }
        }
    }

    public void Die()
    {
        Debug.Log("Enemy Dead");
        TrySpawnPowerUp(); // Försök spawna en power-up
        gameManager.EnemyKilled();
        Destroy(gameObject);
    }

    private void DamageParticles()
    {
        Instantiate(damageParticles, transform.position, Quaternion.identity);
    }

    private void TrySpawnPowerUp()
    {
        // Kontrollera om vi ska spawna en power-up
        if (Random.value <= dropChance && supplies.Length > 0)
        {
            SpawnRandomPowerUp();
        }
    }

    private void SpawnRandomPowerUp()
    {
        // Välj en slumpmässig power-up från listan
        GameObject selectedPowerUp = supplies[Random.Range(0, supplies.Length)];

        // Spawn power-up vid fiendens position
        Instantiate(selectedPowerUp, transform.position, Quaternion.identity);
    }

}
