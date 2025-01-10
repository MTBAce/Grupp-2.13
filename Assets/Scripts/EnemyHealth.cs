using UnityEngine;


public class EnemyHealth : MonoBehaviour
{

    private float health = 50f;

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

        if (health == 0)
        {
            Die();

        }
    }

    private void Die()
    {
        
        Destroy(gameObject);
        Debug.Log("Enemy Dead");
    }
}
