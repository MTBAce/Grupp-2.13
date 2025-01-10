using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField ]float stopDistance;

    private Transform player;

    private void Start()
    {
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



