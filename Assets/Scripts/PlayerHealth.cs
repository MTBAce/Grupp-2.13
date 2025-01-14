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

    public CameraFollow cameraShake;

    

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
        Debug.Log("Player Health: " + health +  ", Enemy damage: " + enemyAI.config.damage);
        cameraShake.TriggerShake(0.3f, 0.8f);


        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);
        if (health <= 0)
        {
            gameManager.KillPlayer();
        }
    }   
}




