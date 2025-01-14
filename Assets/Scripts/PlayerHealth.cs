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

    void Start()
    {
        maxHealth = health;
    }

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
        health -= enemyAI.config.damage;
        Debug.Log(health);
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);
        if (health <= 0)
        {

        }

    }


    

}




