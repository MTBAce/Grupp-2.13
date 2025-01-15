using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem damageParticles;
    
    public EnemyConfig config;
    public GameManager gameManager;

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
        //Debug.Log("Enemy Dead");
        gameManager.EnemyKilled();
        Destroy(gameObject);      
    }

    private void DamageParticles()
    {
        Instantiate(damageParticles, transform.position, Quaternion.identity);
    }

}
