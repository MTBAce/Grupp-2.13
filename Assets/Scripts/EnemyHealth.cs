using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem damageParticles;

    public EnemyConfig config;
    public GameManager gameManager;

    [Header("Power-Up Settings")]
    public GameObject[] powerUps; // Lista över möjliga power-ups
    [Range(0f, 1f)] public float dropChance = 0.5f; // Sannolikheten att en power-up spawnar (0-1)

    private float health;
    public int pointsOnDeath = 10; // Poäng som ges när fienden dör

    private PlayerWeaponHandler playerWeaponHandler;

    private void Start()
    {
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
        health -= playerWeaponHandler.currentWeapon.weaponData.damage;
        Debug.Log("Enemy took damage, health: " + health);
        DamageParticles();

        if (health <= 0)
        {
            Die();
            // Hitta Score-komponenten i scenen
            Score score = FindFirstObjectByType<Score>();

            if (score != null)
            {
                // Lägg till poäng till spelaren
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
        if (Random.value <= dropChance && powerUps.Length > 0)
        {
            SpawnRandomPowerUp();
        }
    }

    private void SpawnRandomPowerUp()
    {
        // Välj en slumpmässig power-up från listan
        GameObject selectedPowerUp = powerUps[Random.Range(0, powerUps.Length)];

        // Spawn power-up vid fiendens position
        Instantiate(selectedPowerUp, transform.position, Quaternion.identity);
    }
}
