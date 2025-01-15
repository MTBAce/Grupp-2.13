using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float moveSpeed;
    private float stopDistance;
    [NonSerialized] int damage;

    public EnemyConfig config;
    public GameManager gameManager;

    private Transform player;

    private void Start()
    {
        moveSpeed = config.moveSpeed;
        stopDistance = config.stopDistance;
        damage = config.damage;
        
        player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            ChasePlayer();
            LookTowardsPlayer();
        }
    }

    private void ChasePlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if(distance > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void LookTowardsPlayer()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.up = direction;
    }
}



