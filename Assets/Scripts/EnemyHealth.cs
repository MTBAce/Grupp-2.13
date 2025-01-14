using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem damageParticles;
    
    public EnemyConfig config;

    private float health;
    public int pointsOnDeath = 10; // Po�ng som ges n�r fienden d�r

  
    private void Start()
    {
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
        health -= 10;
        Debug.Log("Enemy took damage, health: " + health);
        DamageParticles();

        if (health == 0)
        {
            Die();
            // Hitta Score-komponenten i scenen
            Score score = FindFirstObjectByType<Score>();

            if (score != null)
            {
                // L�gg till po�ng till spelaren
                score.AddPoints(pointsOnDeath);
            }

 
        }
    }

    private void Die()
    {
     
        
        Destroy(gameObject);
        Debug.Log("Enemy Dead");
    }

    private void DamageParticles()
    {
        Instantiate(damageParticles, transform.position, Quaternion.identity);
    }

}
