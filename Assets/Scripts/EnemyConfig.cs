using UnityEngine;


[CreateAssetMenu(fileName = "EnemyConfig", menuName = "Enemy/Config", order = 1)]
public class EnemyConfig : ScriptableObject

{
    [Header("Enemy Config")]
    public float health;
    public float moveSpeed;
    public float stopDistance;
    public int scoreValue;

   /* [Header("Spawn Config")]
    public float swarmerInterval;*/

}
