using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int playerHealth;
    EnemyAI enemyAI;

    [NonSerialized] int damage;

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyAI = FindFirstObjectByType<EnemyAI>();
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        playerHealth -= enemyAI.config.damage;
        Debug.Log(playerHealth);
        if (playerHealth <= 0)
        {

        }

    }

    


}
